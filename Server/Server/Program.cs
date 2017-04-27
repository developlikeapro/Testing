using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipend = new IPEndPoint(IPAddress.Loopback, 11000);
            s.Bind(ipend);
            s.Listen(10);

            Socket ss = s.Accept();
            Console.WriteLine("Client Connected");
            x:
            Console.WriteLine("Enter 1 to Receive 2 to Send and 3 to Close");
            
            int a = Convert.ToInt32(Console.ReadLine());
            if (a == 1)
            {
                Console.WriteLine("Msg Receive!");
                byte[] b = new byte[1024];

                int count = ss.Receive(b);
                Console.WriteLine(ASCIIEncoding.ASCII.GetString(b, 0, count));
               // ss.Close();
                goto x;
                
            }
            else if (a == 2)
            {
                Console.WriteLine("Write Your Msg");
                string input = Console.ReadLine();
                ss.Send(ASCIIEncoding.ASCII.GetBytes(input));
                Console.WriteLine("Msg Sending...");
                //ss.Close();
                goto x;
            }
           
            else
            {
                ss.Close();
            }
        }
    }
}
