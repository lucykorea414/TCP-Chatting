using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace TCP_async_client
{
    public partial class clientForm : Form
    {
        Socket mainSock;

        int buffer = 4096;

        string id;


        public clientForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(btnConnect.Text == "Connect")
            {
                mainSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

                id = txtCliID.Text.Trim();

                try
                {
                    mainSock.Connect(txtSvrIP.Text, int.Parse(txtPortNum.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                AsyncObject obj = new AsyncObject(buffer)
                {
                    WorkingSocket = mainSock
                };
                try
                {
                    mainSock.BeginReceive(obj.Buffer, 0, obj.BufferSize, 0, DataReceived, obj);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
                }
            }
            else
            {
                //<End> 보내고 정상종료
            }
        }

        public void DataReceived(IAsyncResult ar)
        {
            AsyncObject obj = (AsyncObject)ar.AsyncState;

            try
            {
                int received = obj.WorkingSocket.EndReceive(ar);
                if (received <= 0)
                {
                    obj.WorkingSocket.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }

            string text = Encoding.Unicode.GetString(obj.Buffer);

            try
            {
                if (text.Contains("<SrvMsg>"))
                {

                }
                else if (text.Contains("<SMsg>"))
                {

                }
            }
        }
    }
}
