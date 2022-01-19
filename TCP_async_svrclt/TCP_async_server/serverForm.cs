using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace TCP_async_server
{
    public partial class serverForm : Form
    {
        Socket mainSock;
        IPAddress thisAddress;
        IPEndPoint serverEP;

        Dictionary<IPEndPoint, Client> connectedClients = new Dictionary<IPEndPoint, Client>();

        //최대 동시접속자 수
        int backlog = 10;

        public serverForm()
        {
            InitializeComponent();

            mainSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            IPHostEntry he = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress addr in he.AddressList)
            {
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    thisAddress = addr;
                    break;
                }
            }
            if (thisAddress == null)
            {
                thisAddress = IPAddress.Loopback;
            }

            txtSvrIP.Text = thisAddress.ToString();
        }

        public void DataReceived(IAsyncResult ar)
        {
            AsyncObject obj = (AsyncObject)ar.AsyncState;

            IPEndPoint ip = (IPEndPoint)obj.WorkingSocket.RemoteEndPoint;
            string id = connectedClients[ip].getID();

            try
            {
                int received = obj.WorkingSocket.EndReceive(ar);

                if(received <= 0)
                {
                    obj.WorkingSocket.Close();
                    return;
                }
            }
            catch
            {
                //비정상 종료 -> 나중에 로그 남기기

            }
        }

        private void btnSvrOpen_Click(object sender, EventArgs e)
        {

        }
    }
}
