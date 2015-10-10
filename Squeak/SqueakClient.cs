using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Squeak
{
    class SqueakClient
    {
        public static void test()
        {
            // This constructor arbitrarily assigns the local port number.
            int port = 999;
            String ip = "www.contoso.com";
            UdpClient udpClient = new UdpClient(port);

            udpClient.Connect(ip, port);

            // Sends a message to the host to which you have connected.
            Byte[] sendBytes = Encoding.ASCII.GetBytes("Is anybody there?");

            udpClient.Send(sendBytes, sendBytes.Length);
            udpClient.Close();
        }
    }
}
