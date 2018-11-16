using OverlordCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace OverloardClient
{
    class Program
    {
        static void Main(string[] args)
        {


            var server = new Server("http://localhost", "8080");
            var machine = Retriever.GetMachine();
            var id = server.Register(machine);

            while (true)
            {
                var checkin = Retriever.GetCheckIn(2);
                server.CheckIn(checkin);
                Thread.Sleep(2000);
            }
        }
    }
}
