using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Squeak
{
    class SqueakServer
    {
        private TcpListener serverSocket;
        private TcpClient clientSocket;

        public SqueakServer() {

        }

        public void initializeServer(int portNumber) {
            this.serverSocket = null;
            try
            {
                this.serverSocket = new TcpListener(9999);

            }
            catch (SocketException se) {
            }
        } 
    }
}
