using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace TCP_async_server
{
    public partial class serverForm : Form
    {
        Socket mainSock;
        Socket client;
        IPAddress thisAddress;
        IPEndPoint serverEP;

        Dictionary<IPEndPoint, Client> connectedClients = new Dictionary<IPEndPoint, Client>();

        //최대 동시접속자 수
        int backlog = 10;
        
        //최대 버퍼 사이즈 크기
        int buffersize = 4096;
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

        void AcceptCallBack(IAsyncResult ar)
        {
            client = mainSock.EndAccept(ar);
            mainSock.BeginAccept(AcceptCallBack, null);
            AsyncObject obj = new AsyncObject(buffersize)
            {
                WorkingSocket = client
            };

            //connectedClients.Add(client);

            // 클라이언트의 데이터를 받는다.
            client.BeginReceive(obj.Buffer, 0, 8192, 0, DataReceived, obj);
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
                        txtChatList.AppendText($"[{id}] : {message}");
                    }));

                    //모든 클라에게 클라 접속 브로드 캐스팅
                }
                else if (text.Contains("<SMsg>"))
                {
                    string[] tokens = text.Split('\x01');
                    string header = tokens[0];
                    string sender = tokens[1];
                    string receiver = tokens[2];
                    string message = tokens[3];

                    string id = connectedClients[ip].getID();

                    //메세지 로그 남기기

                    Invoke(new MethodInvoker(delegate
                    {
                        txtChatList.AppendText($"비밀쪽지[{sender}] -> [{receiver}] : {message}");
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
                else
                {

                }
                obj.ClearBuffer();
                obj.WorkingSocket.BeginReceive(obj.Buffer, 0, buffersize, 0, DataReceived, obj);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "\r\n" + ex.StackTrace);
            }
        }

        private void btnSvrOpen_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(txtSvrPort.Text, out int port))
            {
                MessageBox.Show("포트 번호가 잘못 입력되었거나 입력되지 않았습니다.");
                txtSvrPort.Focus();
                txtSvrPort.SelectAll();
                return;
            }

            try
            {
                serverEP = new IPEndPoint(thisAddress, port);
                mainSock.Bind(serverEP);
                mainSock.Listen(backlog);
                mainSock.BeginAccept(AcceptCallBack, null);

                txtChatList.AppendText("[Server] : Server Start");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //<SvrMsg>
        }

        //클라이언트 전체에게 브로드캐스팅
        public void SendToCli(byte[] text)
        {
            foreach(KeyValuePair<IPEndPoint, Client> kv in connectedClients)
            {
                Socket socket = kv.Value.getSocket();

                try
                {
                    socket.Send(text);
                }
                catch
                {
                    //오류 발생시 전송 취소하고 리스트에서 삭제
                    try
                    {
                        socket.Dispose();
                    }
                    catch { }
                    connectedClients.Remove(kv.Key);
                }
            }
        }

        //특정 클라이언트에게 전달
        public void SendToCli(byte[] text, IPEndPoint ip)
        {
            Socket socket = connectedClients[ip].getSocket();

            try
            {
                socket.Send(text);
            }
            catch
            {
                //오류 발생시 전송 취소하고 리스트에서 삭제
                try
                {
                    socket.Dispose();
                }
                catch { }
                connectedClients.Remove(ip);
            }
        }
    }
}
