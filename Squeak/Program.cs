﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Squeak
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Create UDP client
            int receiverPort = 20000;
            UdpClient receiver = new UdpClient(receiverPort);

            // Display some information
            Console.WriteLine("Starting Upd receiving on port: " + receiverPort);
            Console.WriteLine("Press any key to quit.");
            Console.WriteLine("-------------------------------\n");

            // Start async receiving
            receiver.BeginReceive(DataReceived, receiver);

            // Send some test messages
            using (UdpClient sender1 = new UdpClient(19999))
                sender1.Send(Encoding.ASCII.GetBytes("Hi!"), 3, "localhost", receiverPort);
            using (UdpClient sender2 = new UdpClient(20001))
                sender2.Send(Encoding.ASCII.GetBytes("Hi!"), 3, "localhost", receiverPort);

            // Wait for any key to terminate application
            Console.Read();
        }

        private static void DataReceived(IAsyncResult ar)
        {
            UdpClient c = (UdpClient)ar.AsyncState;
            IPEndPoint receivedIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            Byte[] receivedBytes = c.EndReceive(ar, ref receivedIpEndPoint);

            // Convert data to ASCII and print in console
            string receivedText = ASCIIEncoding.ASCII.GetString(receivedBytes);
            Console.Write(receivedIpEndPoint + ": " + receivedText + Environment.NewLine);

            // Restart listening for udp data packages
            c.BeginReceive(DataReceived, ar.AsyncState);
        }
    }
}