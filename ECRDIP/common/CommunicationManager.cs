using System;
using System.Text;
using System.IO.Ports;
using System.Drawing;

namespace ECRDIP.common
{
    public class CommunicationManager : SerialPort
    {
        #region Manager Enums
        /// <summary>
        /// enumeration to hold our transmission types
        /// </summary>
        public enum TransmissionType { Text, Hex }

        /// <summary>
        /// enumeration to hold our message types
        /// </summary>
        public enum MessageType { Incoming, Outgoing, Normal, Warning, Error };
        #endregion

        #region Manager Variables
        //property variables
        private string _baudRate = string.Empty;
        private string _parity = string.Empty;
        private string _stopBits = string.Empty;
        private string _dataBits = string.Empty;
        private string _portName = string.Empty;
        private TransmissionType _transType;
        //global manager variables
        private Color[] MessageColor = { Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red };
        #endregion

        #region Manager Properties      
        /// <summary>
        /// property to hold our TransmissionType
        /// of our manager class
        /// </summary>
        public TransmissionType CurrentTransmissionType
        {
            get { return _transType; }
            set { _transType = value; }
        }
        #endregion

        #region Manager Constructors
        /// <summary>
        /// Constructor to set the properties of our Manager Class
        /// </summary>
        /// <param name="baud">Desired BaudRate</param>
        /// <param name="par">Desired Parity</param>
        /// <param name="sBits">Desired StopBits</param>
        /// <param name="dBits">Desired DataBits</param>
        /// <param name="name">Desired PortName</param>
        public CommunicationManager(string baud, string par, string sBits, string dBits, string name)
        {
            _baudRate = baud;
            _parity = par;
            _stopBits = sBits;
            _dataBits = dBits;
            _portName = name;           
        }

        /// <summary>
        /// Comstructor to set the properties of our
        /// serial port communicator to nothing
        /// </summary>
        public CommunicationManager()
        {
            _baudRate = string.Empty;
            _parity = string.Empty;
            _stopBits = string.Empty;
            _dataBits = string.Empty;
            _portName = "COM1";            
        }
        #endregion

        #region WriteData
        public string WriteData(string msg)
        {
            string sMsgReturn;

            switch (CurrentTransmissionType)
            {
                case TransmissionType.Text:
                    //first make sure the port is open
                    //if its not open then open it
                    if (!(this.IsOpen == true)) this.Open();
                    //send the message to the port
                    this.Write(msg);
                    //display the message
                    sMsgReturn = msg;
                    break;
                case TransmissionType.Hex:
                    try
                    {
                        //convert the message to byte array
                        byte[] newMsg = DataUtil.HexToByte(msg);
                        //send the message to the port
                        this.Write(newMsg, 0, newMsg.Length);
                        //convert back to hex and display
                        sMsgReturn = DataUtil.ByteToHex(newMsg);
                    }
                    catch (FormatException ex)
                    {
                        throw new FormatException("", ex);
                    }
                    break;
                default:
                    //first make sure the port is open
                    //if its not open then open it
                    if (!(this.IsOpen == true)) this.Open();
                    //send the message to the port
                    this.Write(msg);
                    //display the message
                    sMsgReturn = msg;
                    break;
            }

            return sMsgReturn;
        }
        #endregion

        #region OpenPort
        public void OpenPort()
        {
            try
            {
                //first check if the port is already open
                //if its open then close it
                if (this.IsOpen == true) this.Close();
                //now open the port
                this.Open();                
            }
            catch (Exception ex)
            {
                throw new Exception("Error Open Port", ex);
            }
        }
        #endregion

        #region ClosePort
        public void ClosePort()
        {
            try
            {
                //first check if the port is already open
                //if its open then close it
                if (this.IsOpen) this.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Close Port", ex);
            }
        }
        #endregion

        #region SetParityValues
        public void SetParityValues(object obj)
        {
            ((System.Windows.Forms.ComboBox)obj).Items.Clear();
            foreach (string str in Enum.GetNames(typeof(Parity)))
            {
                ((System.Windows.Forms.ComboBox)obj).Items.Add(str);
            }
        }
        #endregion

        #region SetStopBitValues
        public void SetStopBitValues(object obj)
        {
            ((System.Windows.Forms.ComboBox)obj).Items.Clear();
            foreach (string str in Enum.GetNames(typeof(StopBits)))
            {
                ((System.Windows.Forms.ComboBox)obj).Items.Add(str);
            }
        }
        #endregion

        #region SetPortNameValues
        public void SetPortNameValues(object obj)
        {
            ((System.Windows.Forms.ComboBox)obj).Items.Clear();
            foreach (string str in SerialPort.GetPortNames())
            {
                ((System.Windows.Forms.ComboBox)obj).Items.Add(str);
            }
        }
        #endregion
    }
}
