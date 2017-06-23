using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SieciClient
{
    class Client
    {
        
        public readonly string login;
        public Client(string t)
        {
            login = t;
        }
        private Random random = new Random();
        public void run()
        {
            try
            {

               // TcpClient client = new TcpClient("150.254.79.218", 9001);
                TcpClient client = new TcpClient("127.0.0.1", 9000);

                while (true)
                {

                    

                    String p = ReceivePacket(client).GetAwaiter().GetResult();
                    String moves = "RLS";
                    String begin = "NESW";
                    int randomFIX = 0;
                   /* if (p == null)
                    {
                        int rand = random.Next(1,3);
                    }*/
                    if (p != null && p.Contains("CONNECT") || randomFIX == 3)
                    {
                        sendMsg(client, "LOGIN "+login).GetAwaiter();

                    }
                    if (p != null && (p.Contains("PLAYERS") || p.Contains("ROUND")) ||randomFIX==1 )
                    {
                        int rand = random.Next(0, 3);
                        sendMsg(client, "BEGIN " + begin[rand]).GetAwaiter();
                    }
                    if (p != null && p.Contains("BOARD") || randomFIX == 2)
                    {
                        int rand = random.Next(0, 2);
                        sendMsg(client, "MOVE " + moves[rand]).GetAwaiter();
                    }

                    Thread.Sleep(500);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot connect to server");
                Thread.Sleep(5000);
                
              
            }
        }



        public async Task sendMsg(TcpClient client, string s)
        {
            string msg = string.Format($"{s}\n");
            NetworkStream ns = client.GetStream();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(msg);
            await ns.WriteAsync(bytesToSend, 0, bytesToSend.Length);
            Console.WriteLine("Send " + msg + "to " + client.Client.RemoteEndPoint);
            //  Console.log("Sended: " + s + " to: " + client.Client.RemoteEndPoint);
        }


        public async Task<String> ReceivePacket(TcpClient client)
        {
            String packet = null;
            try
            {
                // First check there is data available
                if (client.Available == 0)
                    return null;

                NetworkStream msgStream = client.GetStream();

                int msgSize = client.Available;
                byte[] lengthBuffer = new byte[msgSize];
                await msgStream.ReadAsync(lengthBuffer, 0, msgSize);//block

                string msg = Encoding.UTF8.GetString(lengthBuffer);
                packet = msg;
                Console.WriteLine("received: " + packet + " From: " + client.Client.RemoteEndPoint);

            }
            catch (Exception e)
            {

                Console.WriteLine("There was an issue sending a packet to." + client.Client.RemoteEndPoint);
                Console.WriteLine("Reason: " + e.StackTrace);
            }

            return packet;
        }
    }
}
