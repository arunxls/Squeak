using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Squeak
{
    class SqueakServer
    {
        private TcpListener serverSocket;
        private TcpClient clientSocket;
        private Int32 port;
        private IPAddress localAddress;
        private String data;
        Byte[] bytes = new Byte[1024];


        public SqueakServer() {

        }

        public void initializeServer(int portNumber) {
            this.serverSocket = null;
            this.clientSocket = null;
            this.port = portNumber;
            localAddress = IPAddress.Parse("127.0.0.1");
            try
            {
                this.serverSocket = new TcpListener(localAddress, portNumber);
                serverSocket.Start();

                while (true)
                {
                    Console.Write("Waiting for a connection...");

                    this.clientSocket = serverSocket.AcceptTcpClient();
                    Console.WriteLine("Connected");

                    this.data = null;

                    NetworkStream stream = this.clientSocket.GetStream();

                    int readLength;

                    while ((readLength = stream.Read(this.bytes, 0, this.bytes.Length)) != 0)
                    {
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, readLength);
                        Console.WriteLine("Received: {0}", data);

                    }


                }

            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException: {0}", se);
            }
            finally {
                this.serverSocket.Stop();
            }
        } 
    }
}
