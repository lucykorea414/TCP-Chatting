using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TCP_async_server
{
    class Client
    {
        IPEndPoint ip;
        Socket socket;
        string id;

        public Client(IPEndPoint ip, Socket socket, string id)
        {
            this.ip = ip;
            this.socket = socket;
            this.id = id;
        }

        public IPEndPoint getIP()
        {
            return ip;
        }

        public Socket getSocket()
        {
            return socket;
        }

        public string getID()
        {
            return id;
        }
    }
}
