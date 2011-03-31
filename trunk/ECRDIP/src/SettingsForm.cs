using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

using HypECR;

namespace ECRDIP.src
{
    public partial class SettingsForm : Form
    {
        //variables for storing values of serial comm properties
        private string _portName = "";
        private string _baudRate = "";
        private string _parity = "";
        private string _dataBits = "";
        private string _stopBits = "";
        private HypECRManager _hypECRManager;
        //private CommunicationManager _commManager = new CommunicationManager();

        //property for setting and getting serial comm properties
        public string PortName
        {
            get
            {
                return _portName;
            }
            set
            {
                _portName = value;
            }
        }

        public string BaudRate
        {
            get
            {
                return _baudRate;
            }
            set
            {
                _baudRate = value;
            }
        }

        public string Parity
        {
            get
            {
                return _parity;
            }
            set
            {
                _parity = value;
            }
        }

        public string DataBits
        {
            get
            {
                return _dataBits;
            }
            set
            {
                _dataBits = value;
            }
        }

        public string StopBits
        {
            get
            {
                return _stopBits;
            }
            set
            {
                _stopBits = value;
            }
        }

        public HypECRManager HypECRManager
        {
            get
            {
                return _hypECRManager;
            }
            set
            {
                _hypECRManager = value;
            }
        }

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                _hypECRManager.PortName = cmbCommPort.Text;
                _hypECRManager.BaudRate = cmbBaudRate.Text;
                _hypECRManager.Parity = cmbParity.Text;
                _hypECRManager.DataBits = cmbDataBits.Text;
                _hypECRManager.StopBits = cmbStopBits.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LoadValues();
            SetDefaults();
        }

        /// <summary>
        /// Method to initialize serial port
        /// values to standard defaults
        /// </summary>
        private void SetDefaults()
        {
            cmbCommPort.SelectedIndex = 0;
            cmbBaudRate.SelectedIndex = 3;
            cmbParity.SelectedIndex = 0;
            cmbStopBits.SelectedIndex = 1;
            cmbDataBits.SelectedIndex = 4;
        }

        /// <summary>
        /// methos to load our serial
        /// port option values
        /// </summary>
        private void LoadValues()
        {
            CommunicationManager.SetPortNameValues(cmbCommPort);
            CommunicationManager.SetParityValues(cmbParity);
            CommunicationManager.SetStopBitValues(cmbStopBits);
        }
    }
}
