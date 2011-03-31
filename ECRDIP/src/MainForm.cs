using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using HypECR;

namespace ECRDIP.src
{
    public partial class MainForm : Form
    {
        SettingsForm settingsForm = new SettingsForm();
        public HypECRManager hypECRManager = new HypECRManager();
        private Color[] MessageColor = { Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red };
        public enum MessageType { Incoming, Outgoing, Normal, Warning, Error };

        public MainForm()
        {
            InitializeComponent();           
            //hypECRManager.IsSecureECR = cbSecureECR.Checked;
            //hypECRManager.DisplayWindow = rtbDisplayData;
            Application.DoEvents();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            settingsForm.HypECRManager = hypECRManager;
            settingsForm.ShowDialog();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            hypECRManager.ClosePort();
        }

        private void btnCloseComm_Click(object sender, EventArgs e)
        {
            try
            {
                hypECRManager.ClosePort();
                //display message
                DisplayData(MessageType.Normal, "Port closed at " + DateTime.Now + "\n");

                btnOpenComm.Enabled = true;
                btnCloseComm.Enabled = false;
                btnSend.Enabled = false;
            }
            catch (Exception ex)
            {
                DisplayData(MessageType.Error, ex.Message);
                DisplayData(MessageType.Error, ex.StackTrace);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {            
            btnCloseComm.Enabled = false;
            btnSend.Enabled = false;

            //String s = DataUtil.DecryptStringTripleDES("6D58A2BFF10EB34FE6A1F8CDB3C1D5BA", "0102030405");
            //String s1 = DataUtil.DecryptStringTripleDES("6D58A2BFF10EB34FE6A1F8CDB3C1D5BA", "0102030405      ");
        }        

        private void btnOpenComm_Click(object sender, EventArgs e)
        {
            try
            {
                if (hypECRManager.OpenPort())
                {
                    //display message
                    DisplayData(MessageType.Normal, "Port opened at " + DateTime.Now + "\n");

                    if (cbSecureECR.Checked)
                    {
                        //DisplayData(CommunicationManager.MessageType.Outgoing, hypECRManager.Authenticate() + "\n");                        
                        //hypECRManager.Authenticate();
                    }

                    //now add an event handler
                    //hypECRManager.CommManager.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
                    btnOpenComm.Enabled = false;
                    btnCloseComm.Enabled = true;
                    btnSend.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                //hypECRManager.CommManager.Close();
                DisplayData(MessageType.Error, ex.Message + Environment.NewLine);
                DisplayData(MessageType.Error, ex.StackTrace + Environment.NewLine);
            }  
        }

        private void btnSend_Click(object sender, EventArgs e)
        {            
            FieldResponse fieldResponse = new FieldResponse();
            int iSaleAmount;
            int iSaleCashAmount;
            int iSaleCashCashBack;
            int iRefundAmount;
            int iOnePursePaymentAmount;           

            iSaleAmount = int.Parse(mtbSaleAmount.Text);
            iSaleCashAmount = int.Parse(mtbSaleCashAmount.Text);
            iSaleCashCashBack = int.Parse(mtbSaleCashCashBack.Text);
            iRefundAmount = int.Parse(mtbRefundAmount.Text);
            iOnePursePaymentAmount = int.Parse(mtbOnePursepaymentAmount.Text);

            try
            {
                if (tabControl1.SelectedTab == tpSale)
                {
                    fieldResponse = hypECRManager.SendSaleCommand(iSaleAmount);
                }
                else if (tabControl1.SelectedTab == tpVoid)
                {
                    fieldResponse = hypECRManager.SendVoidCommand(tbInvoiceNumber.Text);
                }
                else if (tabControl1.SelectedTab == tpSaleCash)
                {
                    fieldResponse = hypECRManager.SendSaleCashCommand(iSaleCashAmount, iSaleCashCashBack);
                }
                else if (tabControl1.SelectedTab == tpRefund)
                {
                    fieldResponse = hypECRManager.SendRefundCommand(iRefundAmount);
                }
                else if (tabControl1.SelectedTab == tpSettlement)
                {
                    fieldResponse = hypECRManager.SendSettleCommand(tbNII.Text);
                }
                else if (tabControl1.SelectedTab == tpOnePursePayment)
                {
                    fieldResponse = hypECRManager.SendOnePursePaymentCommand(iOnePursePaymentAmount);
                }
                else if (tabControl1.SelectedTab == tpOnePurseVoid)
                {
                    fieldResponse = hypECRManager.SendOnePurseVoidCommand();
                }
                DisplayData(MessageType.Normal, fieldResponse + "\n");
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);

                MessageBox.Show(trace.GetFrame(0).GetMethod().Name);
                MessageBox.Show("Line: " + trace.GetFrame(0).GetFileLineNumber());
                MessageBox.Show("Column: " + trace.GetFrame(0).GetFileColumnNumber());

                DisplayData(MessageType.Error, ex.Message + "\n");
                DisplayData(MessageType.Error, ex.StackTrace + "\n");
            }
        }

        #region comPort_DataReceived
        /// <summary>
        /// method that will be called when theres data waiting in the buffer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            HypECRManager.FieldResponse fr = new HypECRManager.FieldResponse();
            try
            {
                //determine the mode the user selected (binary/string)
                switch (hypECRManager.CommManager.CurrentTransmissionType)
                {
                    //user chose string
                    case CommunicationManager.TransmissionType.Text:
                        //read data waiting in the buffer
                        string msg = hypECRManager.CommManager.ReadExisting();
                        //display the data to the user
                        DisplayData(CommunicationManager.MessageType.Incoming, msg + "\n");
                        break;
                    //user chose binary
                    case CommunicationManager.TransmissionType.Hex:                        
                        //retrieve number of bytes in the buffer
                        Thread.Sleep(500);                        
                        int bytes = hypECRManager.CommManager.BytesToRead;

                        if (bytes > 0)
                        {
                            //create a byte array to hold the awaiting data
                            byte[] comBuffer = new byte[bytes];
                            //read the data and store it
                            hypECRManager.CommManager.Read(comBuffer, 0, bytes);

                            //display the data to the user
                            DisplayData(CommunicationManager.MessageType.Incoming, HypECR.DataUtil.ByteToHex(comBuffer) + "\n");

                            if (bytes == 1)
                            {
                                _isACK = hypECRManager.WaitACK(comBuffer);
                            }
                            else if (_isACK)
                            {
                                string sMessage = HypECR.DataUtil.ByteToHex(comBuffer);
                                if (sMessage.Length != 0)
                                {                                    
                                    fr = hypECRManager.ExtractMessage(sMessage);
                                    DisplayData(CommunicationManager.MessageType.Normal, fr.ToString());
                                    DisplayData(CommunicationManager.MessageType.Outgoing, hypECRManager.SendACK() + "\n");
                                }
                            }
                           
                        }
                        break;
                    default:
                        //read data waiting in the buffer
                        string str = hypECRManager.CommManager.ReadExisting();
                        //display the data to the user
                        DisplayData(CommunicationManager.MessageType.Incoming, str + "\n");
                        break;
                        
                }
                
            }
            catch (Exception ex)
            {
                DisplayData(CommunicationManager.MessageType.Error, ex.Message + Environment.NewLine);
                DisplayData(CommunicationManager.MessageType.Error, ex.StackTrace + Environment.NewLine);
            }
        }*/
        #endregion

        #region DisplayData
        /// <summary>
        /// method to display the data to and from the port
        /// on the screen
        /// </summary>
        /// <param name="type">MessageType of the message</param>
        /// <param name="msg">Message to display</param>
        [STAThread]
        private void DisplayData(MessageType type, string msg)
        {
            rtbDisplayData.Invoke(new EventHandler(delegate
            {
                rtbDisplayData.SelectedText = string.Empty;
                rtbDisplayData.SelectionFont = new Font(rtbDisplayData.SelectionFont, FontStyle.Bold);
                rtbDisplayData.SelectionColor = MessageColor[(int)type];
                rtbDisplayData.AppendText(msg);
                rtbDisplayData.ScrollToCaret();
            }));
        }
        #endregion

        private void cbSecureECR_CheckedChanged(object sender, EventArgs e)
        {
            //hypECRManager.IsSecureECR = cbSecureECR.Checked;
        }
    }
}
