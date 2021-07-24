using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text.RegularExpressions;

namespace OpenPop.Imap123
{

    public class TcpIMAP
    {
        private TcpClient _imapClient;
        private NetworkStream _imapNs;
        private StreamWriter _imapSw;
        private StreamReader _imapSr;

        public TcpIMAP()
        {

        }

        public TcpIMAP(string hostname, int port)
        {
            InitializeConnection(hostname, port);
        }

        public void Connect(string hostname, int port)
        {
            InitializeConnection(hostname, port);
        }

        private void InitializeConnection(string hostname, int port)
        {
            try
            {
                _imapClient = new TcpClient(hostname, port);
                _imapNs = _imapClient.GetStream();
                _imapSw = new StreamWriter(_imapNs);
                _imapSr = new StreamReader(_imapNs);

                Console.WriteLine("*** Connected ***");
                Response();
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void AuthenticateUser(string username, string password)
        {
            _imapSw.WriteLine("$ LOGIN " + username + " " + password);
            _imapSw.Flush();
            Response();
        }


        public int MailCount()
        {
            _imapSw.WriteLine("$ STATUS INBOX (messages)");
            _imapSw.Flush();

            string res = Response();
            Match m = Regex.Match(res, "[0-9]*[0-9]");
            return Convert.ToInt32(m.ToString());
        }

        public int MailUnreadCount()
        {
            _imapSw.WriteLine("$ STATUS INBOX (unseen)");
            _imapSw.Flush();

            string res = Response();
            Match m = Regex.Match(res, "[0-9]*[0-9]");
            return Convert.ToInt32(m.ToString());
        }


        public void SelectInbox()
        {
            _imapSw.WriteLine("$ SELECT INBOX");
            _imapSw.Flush();
            Response();
        }


        public object GetMessageHeaders(int index)
        {
            _imapSw.WriteLine("$ FETCH " + index + " (body[header.fields (from subject date)])");
            _imapSw.Flush();

            return Response();
        }

        public object GetMessage(int index)
        {
            _imapSw.WriteLine("$ FETCH " + index + " body[text]");
            _imapSw.Flush();

            return Response();
        }


        public void Disconnect()
        {
            _imapSw.WriteLine("$ LOGOUT");
            _imapSw.Flush();
            _imapClient.Close();
        }

        private string Response()
        {
            byte[] data = new byte[_imapClient.ReceiveBufferSize];
            int ret = _imapNs.Read(data, 0, data.Length);
            return Encoding.ASCII.GetString(data).TrimEnd();
        }

    }
}
