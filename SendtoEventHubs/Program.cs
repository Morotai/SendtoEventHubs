using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Core;

namespace SendtoEventHubs
{
    class Program
    {
        //static string eventHubName = "masaipdata";
        static string connectionString = "Endpoint=sb://somosevents.servicebus.windows.net/;SharedAccessKeyName=defaultpolicy;SharedAccessKey=Tshxz4udJyPw0rZEP11JX4ux9Mf+TaoXuITteyHDJmM=;EntityPath=masaipdata";
        static void Main(string[] args)
        {
            Console.WriteLine("Press Ctrl-C to stop the sender process");
            Console.WriteLine("Press Enter to start now");
            Console.ReadLine();
            SendingRandomMessages();
            Console.ReadLine();
        }

        static void SendingRandomMessages()
        {
            var eventHubClient = EventHubClient.CreateFromConnectionString(connectionString);
            while (true)
            {
                try
                {
                    var message = Guid.NewGuid().ToString();
                    Console.WriteLine("{0} > Rafael is Sending a message: {1}", DateTime.Now, message);
                    eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(message)));
                }
                catch (Exception exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} > Exception: {1}", DateTime.Now, exception.Message);
                    Console.ResetColor();
                }

                Thread.Sleep(200);
            }
        }
    }
}
