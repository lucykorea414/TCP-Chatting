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
            //string id = connectedClients[ip].getID();

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
                obj.WorkingSocket.Close();
                connectedClients.Remove(ip);
                string id = connectedClients[ip].getID();

                //listview에서 삭제
                Invoke(new MethodInvoker(delegate
                {
                    ClientList.BeginUpdate();

                    for (int i = 0; i < ClientList.Items.Count; i++)
                    {
                        if (ClientList.Items[i].SubItems[0].Text.Equals(id)){
                            ClientList.Items.RemoveAt(i);
                        }
                    }

                    ClientList.EndUpdate();
                }));
                
                //모든 클라에게 클라 접속 종료 브로드캐스팅

                return;
            }

            try
            {
                string text = Encoding.Unicode.GetString(obj.Buffer);

                if (text.Contains("<Client>"))
                {
                    string[] tokens = text.Split('\x01');
                    string header = tokens[0];
                    string id = tokens[1];

                    //나중에 데이터베이스와 아이디 비교해서 
                    Client c = new Client(ip, obj.WorkingSocket, id);
                    connectedClients.Add(ip, c);
                    //클라 접속 완료 로그 남기기

                    Invoke(new MethodInvoker(delegate
                    {
                        ClientList.BeginUpdate();

                        string[] clientInfo = { id, ip.ToString() };
                        ListViewItem item = new ListViewItem(clientInfo);
                        ClientList.Items.Add(item);

                        ClientList.EndUpdate();
                    }));

                    //모든 클라에게 클라 접속 브로드캐스팅
                }
                else if (text.Contains("<Msg>"))
                {
                    string[] tokens = text.Split('\x01');
                    string header = tokens[0];
                    string message = tokens[1];

                    string id = connectedClients[ip].getID();

                    //메세지 로그 남기기

                    Invoke(new MethodInvoker(delegate
                    {
                        txtChatList.AppendText($"[{id}]: {message}");
                    }));

                    //모든 클라에게 클라 접속 브로드 캐스팅
                }
                else if (text.Contains("<SMsg>"))
                {
                    string[] tokens = text.Split('\x01');
                    string header = tokens[0];
                    string receiver = tokens[1];
                    string message = tokens[2];

                    string id = connectedClients[ip].getID();

                    //메세지 로그 남기기

                    Invoke(new MethodInvoker(delegate
                    {
                        txtChatList.AppendText($"비밀쪽지[{id}] -> [{receiver}]: {message}");
                    }));

                    //sendtoclient 메서드 호출

                }
                else if (text.Contains("<End>"))
                {
                    obj.WorkingSocket.Close();
                    connectedClients.Remove(ip);
                    string id = connectedClients[ip].getID();

                    //listview에서 삭제
                    Invoke(new MethodInvoker(delegate
                    {
                        ClientList.BeginUpdate();

                        for (int i = 0; i < ClientList.Items.Count; i++)
                        {
                            if (ClientList.Items[i].SubItems[0].Text.Equals(id))
                            {
                                ClientList.Items.RemoveAt(i);
                            }
                        }

                        ClientList.EndUpdate();
                    }));

                    //모든 클라에게 클라 접속 종료 브로드캐스팅

                    return;
                }
            }
        }

        private void btnSvrOpen_Click(object sender, EventArgs e)
        {

        }
    }
}
