using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECRDIP.common
{
    class HypECR
    {
        private CommunicationManager _commManager;

        public static String ACK = "06";
        public static String STX = "02";
        public static String ETX = "03";
        public static String FieldSeparator = "1C";
        public static String TRANSACTION_CODE_SALE = "20";
        public static String TRANSACTION_CODE_SALECASH = "20";
        //public static String TRANSACTION_CODE_SALE = "20";

        class TransportHeader
        {
            private string _transportHeaderType = "60";
            private string _transportDestination = "0000";
            private string _transportSource = "0000";
            private static int _length = 10;

            public String TransportHeaderType
            {
                get { return _transportHeaderType; }
                set { _transportHeaderType = value; }
            }

            public String TransportDestination
            {
                get { return _transportDestination; }
                set { _transportDestination = value; }
            }

            public String TransportSource
            {
                get { return _transportSource; }
                set { _transportSource = value; }
            }

            public static int Length
            {
                get { return _length; }
            }

            public String GetMessage()
            {
                string sTemp = String.Empty;

                sTemp += DataUtil.ConvertToHex(_transportHeaderType + _transportDestination + _transportSource); 

                return sTemp;
            }
        }

        class PresentationHeader
        {
            private string _formatVersion = "1";
            private string _requestResponseIndicator = String.Empty;
            private string _transactionCode = String.Empty;
            private string _responseCode = String.Empty;
            private string _moreIndicator = String.Empty;
            private string _fieldSeparator = HypECR.FieldSeparator;
            private string _transportHeaderType = String.Empty;
            private string _transportDestination = String.Empty;
            private string _transportSource = String.Empty;

            public static string RequestResponse = "0";
            public static string Response = "1";
            public static string Request = "2";
            public static string LastMessage = "0";
            public static string AnotherMessage = "1";           

            public String FormatVersion
            {
                get { return _formatVersion; }
                set { _formatVersion = value; }
            }

            public String RequestResponseIndicator
            {
                get { return _requestResponseIndicator; }
                set { _requestResponseIndicator = value; }
            }

            public String TransactionCode
            {
                get { return _transactionCode; }
                set { _transactionCode = value; }
            }

            public String ResponseCode
            {
                get { return _responseCode; }
                set { _responseCode = value; }
            }

            public String MoreIndicator
            {
                get { return _moreIndicator; }
                set { _moreIndicator = value; }
            }

            public String FieldSeparator
            {
                get { return _fieldSeparator; }
                set { _fieldSeparator = value; }
            }

            public String GetMessage()
            {
                string sTemp = String.Empty;

                sTemp += DataUtil.ConvertToHex(_formatVersion + _requestResponseIndicator + _transactionCode + _responseCode + _moreIndicator) + _fieldSeparator;

                return sTemp;
            }
        }

        class FieldElement
        {
            private string _fieldType = String.Empty;
            private string _fieldLength = String.Empty;
            private string _fieldData = String.Empty;
            private string _fieldSeparator = HypECR.FieldSeparator;

            public String FieldType
            {
                get { return _fieldType; }
                set { _fieldType = value; }
            }

            public String FieldLength
            {
                get { return _fieldLength; }
                set { _fieldLength = value; }
            }

            public String FieldData
            {
                get { return _fieldData; }
                set { _fieldData = value; }
            }

            public String FieldSeparator
            {
                get { return _fieldSeparator; }
                set { _fieldSeparator = value; }
            }

            public String GetMessage()
            {
                string sTemp = String.Empty;

                sTemp += DataUtil.ConvertToHex(_fieldType) + _fieldLength + DataUtil.ConvertToHex(_fieldData) + _fieldSeparator;

                return sTemp;
            }
        }

        public class FieldResponse
        {
            private string _approvalCode = String.Empty;
            private string _responseText = String.Empty;
            private string _transactionDate = String.Empty;
            private string _transactionTime = String.Empty;
            private string _terminalID = String.Empty;
            private string _cardNumber = String.Empty;
            private string _expiryDate = String.Empty;
            private string _amountTransaction = String.Empty;
            private string _amountTip = String.Empty;
            private string _batchNumber = String.Empty;
            private string _batchAmount = String.Empty;
            private string _invoiceNumber = String.Empty;
            private string _merchantNameAndAddress = String.Empty;
            private string _merchantNumber = String.Empty;
            private string _cardIssuerName = String.Empty;
            private string _retrievalReferenceNumber = String.Empty;
            private string _cardIssuerID = String.Empty;
            private string _cardHolderName = String.Empty;
            private string _systemTraceNo = String.Empty;
            private string _batchTotal = String.Empty;
            private string _nii = String.Empty;
            private string _transactionCode = String.Empty;
            private string _responseCode = String.Empty;

            public String ApprovalCode
            {
                get { return _approvalCode; }
                set { _approvalCode = value; }
            }

            public String ResponseText
            {
                get { return _responseText; }
                set { _responseText = value; }
            }

            public String TransactionDate
            {
                get { return _transactionDate; }
                set { _transactionDate = value; }
            }

            public String TransactionTime
            {
                get { return _transactionTime; }
                set { _transactionTime = value; }
            }

            public String TerminalID
            {
                get { return _terminalID; }
                set { _terminalID = value; }
            }

            public String CardNumber
            {
                get { return _cardNumber; }
                set { _cardNumber = value; }
            }

            public String ExpiryDate
            {
                get { return _expiryDate; }
                set { _expiryDate = value; }
            }

            public String AmountTransaction
            {
                get { return _amountTransaction; }
                set { _amountTransaction = value; }
            }

            public String AmountTip
            {
                get { return _amountTip; }
                set { _amountTip = value; }
            }

            public String BatchNumber
            {
                get { return _batchNumber; }
                set { _batchNumber = value; }
            }

            public String BatchAmount
            {
                get { return _batchAmount; }
                set { _batchAmount = value; }
            }

            public String InvoiceNumber
            {
                get { return _invoiceNumber; }
                set { _invoiceNumber = value; }
            }

            public String MerchantNameAndAddress
            {
                get { return _merchantNameAndAddress; }
                set { _merchantNameAndAddress = value; }
            }

            public String MerchantNumber
            {
                get { return _merchantNumber; }
                set { _merchantNumber = value; }
            }

            public String CardIssuerName
            {
                get { return _cardIssuerName; }
                set { _cardIssuerName = value; }
            }

            public String RetrievalReferenceNumber
            {
                get { return _retrievalReferenceNumber; }
                set { _retrievalReferenceNumber = value; }
            }

            public String CardIssuerID
            {
                get { return _cardIssuerID; }
                set { _cardIssuerID = value; }
            }

            public String CardHolderName
            {
                get { return _cardHolderName; }
                set { _cardHolderName = value; }
            }

            public String SystemTraceNo
            {
                get { return _systemTraceNo; }
                set { _systemTraceNo = value; }
            }

            public String BatchTotal
            {
                get { return _batchTotal; }
                set { _batchTotal = value; }
            }

            public String NII
            {
                get { return _nii; }
                set { _nii = value; }
            }

            public String TransactionCode
            {
                get { return _transactionCode; }
                set { _transactionCode = value; }
            }

            public String ResponseCode
            {
                get { return _responseCode; }
                set { _responseCode = value; }
            }

            public void ParseMessage(string pFieldData)
            {
                try
                {

                    int iPtr = 0;
                    do
                    {
                        if (iPtr >= pFieldData.Length)
                            break;
                        string sFieldType = DataUtil.HexAsciiConvert(pFieldData.Substring(iPtr, 4));
                        iPtr += 4;
                        int iLength = int.Parse(pFieldData.Substring(iPtr, 4));
                        iPtr += 4;
                        string sFieldData = DataUtil.HexAsciiConvert(pFieldData.Substring(iPtr, iLength * 2));
                        iPtr += iLength * 2;
                        if (sFieldType.Equals("01"))
                        {
                            this._approvalCode = sFieldData;
                        }
                        else if (sFieldType.Equals("02"))
                        {
                            this._responseText = sFieldData;
                        }
                        else if (sFieldType.Equals("03"))
                        {
                            this._transactionDate = sFieldData;
                        }
                        else if (sFieldType.Equals("04"))
                        {
                            this._transactionTime = sFieldData;
                        }
                        else if (sFieldType.Equals("16"))
                        {
                            this._terminalID = sFieldData;
                        }
                        else if (sFieldType.Equals("30"))
                        {
                            this._cardNumber = sFieldData;
                        }
                        else if (sFieldType.Equals("31"))
                        {
                            this._expiryDate = sFieldData;
                        }
                        else if (sFieldType.Equals("40"))
                        {
                            float fAmount = float.Parse(sFieldData) / 100;
                            this._amountTransaction = fAmount.ToString();
                        }
                        else if (sFieldType.Equals("41"))
                        {
                            float fAmount = float.Parse(sFieldData) / 100;
                            this._amountTip = fAmount.ToString();
                        }
                        else if (sFieldType.Equals("50"))
                        {
                            this._batchNumber = sFieldData;
                        }
                        else if (sFieldType.Equals("52"))
                        {
                            float fAmount = float.Parse(sFieldData) / 100;
                            this._batchAmount = fAmount.ToString();
                        }
                        else if (sFieldType.Equals("65"))
                        {
                            this._invoiceNumber = sFieldData;
                        }
                        else if (sFieldType.Equals("D0"))
                        {
                            this._merchantNameAndAddress = sFieldData;
                        }
                        else if (sFieldType.Equals("D1"))
                        {
                            this._merchantNumber = sFieldData;
                        }
                        else if (sFieldType.Equals("D2"))
                        {
                            this._cardIssuerName = sFieldData;
                        }
                        else if (sFieldType.Equals("D3"))
                        {
                            this._retrievalReferenceNumber = sFieldData;
                        }
                        else if (sFieldType.Equals("D4"))
                        {
                            this._cardIssuerID = sFieldData;
                        }
                        else if (sFieldType.Equals("D5"))
                        {
                            this._cardHolderName = sFieldData;
                        }
                        else if (sFieldType.Equals("D9"))
                        {
                            this._systemTraceNo = sFieldData;
                        }
                        else if (sFieldType.Equals("H0"))
                        {
                            this._batchTotal = sFieldData;
                        }
                        else if (sFieldType.Equals("HN"))
                        {
                            this._nii = sFieldData;
                        }

                        if (pFieldData.Substring(iPtr, 2).Equals("1C"))

                            iPtr += 2;

                    } while (iPtr < pFieldData.Length);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Transaction Code : " + _transactionCode + "\n");
                sb.Append("Response Code : " + _responseCode + "\n");
                sb.Append("Approval Code : " + _approvalCode + "\n" );
                sb.Append("Response Text : " + _responseText + "\n");
                sb.Append("Transaction Date : " + _transactionDate + "\n" );
                sb.Append("Transaction Time : " + _transactionTime + "\n" );
                sb.Append("Terminal ID : " + _terminalID + "\n" );
                sb.Append("Card Number : " + _cardNumber + "\n" );
                sb.Append("Expiry Date : " + _expiryDate + "\n" );
                sb.Append("Amount Transaction : " + _amountTransaction + "\n" );
                sb.Append("Amount TIP : " + _amountTip + "\n" );
                sb.Append("Batch Number : " + _batchNumber + "\n" );
                sb.Append("Batch Amount : " + _batchAmount + "\n" );
                sb.Append("Invoice Number : " + _invoiceNumber + "\n" );
                sb.Append("Merchant Name And Address : " + _merchantNameAndAddress + "\n" );
                sb.Append("Merchant Number : " + _merchantNumber + "\n" );
                sb.Append("Card Issuer Name : " + _cardIssuerName + "\n" );
                sb.Append("Retrieval Reference Number : " + _retrievalReferenceNumber + "\n" );
                sb.Append("Card Issuer ID : " + _cardIssuerID + "\n" );
                sb.Append("Card Holder Name : " + _cardHolderName + "\n" );
                sb.Append("System Trace No : " + _systemTraceNo + "\n" );
                sb.Append("Batch Total : " + _batchTotal + "\n" );
                sb.Append("NII : " + _nii + "\n" );

                return sb.ToString();
            }
        }

        /// <summary>
        /// property to hold our Communication Manager
        /// value
        /// </summary>
        public CommunicationManager CommManager
        {
            get { return _commManager; }
            set { _commManager = value; }
        }

        public HypECR()
        {
        }

        public string SendACK()
        {
            string sACK = "06";
            return _commManager.WriteData(sACK);
        }

        public bool WaitACK(byte[] pACK)
        {
            string sACK = "06";
            bool bReturn = false;
            if (pACK.Length == 1)
            {
                if (DataUtil.ByteToHex(pACK).Replace(" ", "").Equals(sACK))
                    bReturn = true;
            }
            return bReturn;
        }

        public string SendSaleCommand(int pAmount)
        {
            string sMessageData = String.Empty;
            string sMessageToSend = String.Empty;
            string sFieldMessage = String.Empty;

            TransportHeader th = new TransportHeader();
            PresentationHeader ph = new PresentationHeader();
            FieldElement fe = new FieldElement();

            ph.RequestResponseIndicator = PresentationHeader.RequestResponse;
            ph.TransactionCode = "20";
            ph.ResponseCode = "00";
            ph.MoreIndicator = PresentationHeader.LastMessage;

            fe.FieldType = "40";
            fe.FieldLength = "0012";
            pAmount *= 100;
            fe.FieldData = DataUtil.ConvertToAmountFormat(pAmount);

            sFieldMessage += fe.GetMessage();

            sMessageData = th.GetMessage() + ph.GetMessage() + sFieldMessage;

            sMessageToSend = PackMessage(sMessageData);

            return _commManager.WriteData(sMessageToSend);
        }

        public string SendVoidCommand(string pInvoiceNumber)
        {
            string sMessageData = String.Empty;
            string sMessageToSend = String.Empty;
            string sFieldMessage = String.Empty;

            TransportHeader th = new TransportHeader();
            PresentationHeader ph = new PresentationHeader();
            FieldElement fe = new FieldElement();

            ph.RequestResponseIndicator = PresentationHeader.RequestResponse;
            ph.TransactionCode = "26";
            ph.ResponseCode = "00";
            ph.MoreIndicator = PresentationHeader.LastMessage;

            fe.FieldType = "65";
            fe.FieldLength = DataUtil.ConvertToLengthFormat(pInvoiceNumber.Length);
            fe.FieldData = pInvoiceNumber;

            sFieldMessage += fe.GetMessage();

            sMessageData = th.GetMessage() + ph.GetMessage() + sFieldMessage;

            sMessageToSend = PackMessage(sMessageData);

            return _commManager.WriteData(sMessageToSend);
        }

        public string SendSaleCashCommand(int pAmount, int pCashBack)
        {
            string sMessageData = String.Empty;
            string sMessageToSend = String.Empty;
            string sFieldMessage = String.Empty;

            TransportHeader th = new TransportHeader();
            PresentationHeader ph = new PresentationHeader();
            FieldElement fe = new FieldElement();

            ph.RequestResponseIndicator = PresentationHeader.RequestResponse;
            ph.TransactionCode = "20";
            ph.ResponseCode = "00";
            ph.MoreIndicator = PresentationHeader.LastMessage;

            fe.FieldType = "40";
            fe.FieldLength = "0012";
            pAmount *= 100;
            fe.FieldData = DataUtil.ConvertToAmountFormat(pAmount);

            sFieldMessage += fe.GetMessage();

            fe.FieldType = "42";
            fe.FieldLength = "0012";
            pCashBack *= 100;
            fe.FieldData = DataUtil.ConvertToAmountFormat(pCashBack);

            sFieldMessage += fe.GetMessage();

            sMessageData = th.GetMessage() + ph.GetMessage() + sFieldMessage;

            sMessageToSend = PackMessage(sMessageData);

            return _commManager.WriteData(sMessageToSend);
        }

        public string SendRefundCommand(int pAmount)
        {
            string sMessageData = String.Empty;
            string sMessageToSend = String.Empty;
            string sFieldMessage = String.Empty;

            TransportHeader th = new TransportHeader();
            PresentationHeader ph = new PresentationHeader();
            FieldElement fe = new FieldElement();

            ph.RequestResponseIndicator = PresentationHeader.RequestResponse;
            ph.TransactionCode = "27";
            ph.ResponseCode = "00";
            ph.MoreIndicator = PresentationHeader.LastMessage;

            fe.FieldType = "40";
            fe.FieldLength = "0012";
            pAmount *= 100;
            fe.FieldData = DataUtil.ConvertToAmountFormat(pAmount);

            sFieldMessage += fe.GetMessage();

            sMessageData = th.GetMessage() + ph.GetMessage() + sFieldMessage;

            sMessageToSend = PackMessage(sMessageData);

            return _commManager.WriteData(sMessageToSend);
        }

        public string SendSettleCommand(string pNII)
        {
            string sMessageData = String.Empty;
            string sMessageToSend = String.Empty;
            string sFieldMessage = String.Empty;

            TransportHeader th = new TransportHeader();
            PresentationHeader ph = new PresentationHeader();
            FieldElement fe = new FieldElement();

            ph.RequestResponseIndicator = PresentationHeader.RequestResponse;
            ph.TransactionCode = "50";
            ph.ResponseCode = "00";
            ph.MoreIndicator = PresentationHeader.LastMessage;

            fe.FieldType = "HN";
            fe.FieldLength = DataUtil.ConvertToLengthFormat(pNII.Length);
            fe.FieldData = pNII;

            sFieldMessage += fe.GetMessage();

            sMessageData = th.GetMessage() + ph.GetMessage() + sFieldMessage;

            sMessageToSend = PackMessage(sMessageData);

            return _commManager.WriteData(sMessageToSend);
        }

        public string SendOnePursePaymentCommand(int pAmount)
        {
            string sMessageData = String.Empty;
            string sMessageToSend = String.Empty;
            string sFieldMessage = String.Empty;

            TransportHeader th = new TransportHeader();
            PresentationHeader ph = new PresentationHeader();
            FieldElement fe = new FieldElement();

            ph.RequestResponseIndicator = PresentationHeader.RequestResponse;
            ph.TransactionCode = "OP";
            ph.ResponseCode = "00";
            ph.MoreIndicator = PresentationHeader.LastMessage;

            fe.FieldType = "40";
            fe.FieldLength = "0012";
            pAmount *= 100;
            fe.FieldData = DataUtil.ConvertToAmountFormat(pAmount);

            sFieldMessage += fe.GetMessage();

            sMessageData = th.GetMessage() + ph.GetMessage() + sFieldMessage;

            sMessageToSend = PackMessage(sMessageData);

            return _commManager.WriteData(sMessageToSend);
        }

        public string SendOnePurseVoidCommand()
        {
            string sMessageData = String.Empty;
            string sMessageToSend = String.Empty;
            string sFieldMessage = String.Empty;

            TransportHeader th = new TransportHeader();
            PresentationHeader ph = new PresentationHeader();
            FieldElement fe = new FieldElement();

            ph.RequestResponseIndicator = PresentationHeader.RequestResponse;
            ph.TransactionCode = "OV";
            ph.ResponseCode = "00";
            ph.MoreIndicator = PresentationHeader.LastMessage;

            sFieldMessage += fe.GetMessage();

            sMessageData = th.GetMessage() + ph.GetMessage() + sFieldMessage;

            sMessageToSend = PackMessage(sMessageData);

            return _commManager.WriteData(sMessageToSend);
        }

        public string PackMessage(string pMessageData)
        {
            string sPackMessage = String.Empty;

            sPackMessage = String.Format("{0:0000}", pMessageData.Length / 2) + pMessageData + ETX;

            sPackMessage = STX + sPackMessage + DataUtil.ConvertToHex(DataUtil.ReturnLRC(sPackMessage).ToString());

            return sPackMessage;
        }

        public FieldResponse ExtractMessage(string pMessage)
        {
            FieldResponse fr = new FieldResponse();
            try
            {                
                int iPtr = 6;
                if (iPtr > pMessage.Length)
                    return fr;
                string sTransportHeader = DataUtil.HexAsciiConvert(pMessage.Substring(iPtr, TransportHeader.Length * 2));
                iPtr += TransportHeader.Length * 2;
                if (!sTransportHeader.Equals("6000000000"))
                    fr.ResponseCode = "XX";

                PresentationHeader ph = new PresentationHeader();
                ph.FormatVersion = DataUtil.HexAsciiConvert(pMessage.Substring(iPtr, 2));
                iPtr += 2;
                ph.RequestResponseIndicator = DataUtil.HexAsciiConvert(pMessage.Substring(iPtr, 2));
                iPtr += 2;
                ph.TransactionCode = DataUtil.HexAsciiConvert(pMessage.Substring(iPtr, 4));
                iPtr += 4;
                ph.ResponseCode = DataUtil.HexAsciiConvert(pMessage.Substring(iPtr, 4));
                iPtr += 4;
                ph.MoreIndicator = DataUtil.HexAsciiConvert(pMessage.Substring(iPtr, 2));
                iPtr += 2;
                ph.FieldSeparator = pMessage.Substring(iPtr, 2);
                iPtr += 2;

                int iLength = pMessage.Length - iPtr - 4;
                fr.TransactionCode = ph.TransactionCode;
                fr.ResponseCode = ph.ResponseCode;
                fr.ParseMessage(pMessage.Substring(iPtr, iLength));
            }
            catch (Exception ex)
            {
               throw ex;
            }
            return fr;
        }

    }
}
