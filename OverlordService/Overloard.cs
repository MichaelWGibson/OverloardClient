using OverlordCore;
using System.ServiceProcess;
using System.Timers;

namespace OverlordService
{
    public partial class Overloard : ServiceBase
    {
        Timer timer;
        Server server;
        Machine machine;
        int? Id;

        public Overloard()
        {
            InitializeComponent();
            machine = Retriever.GetMachine();
            timer = new Timer(1000 * 15);
            timer.Elapsed += Timer_Elapsed;
        }

        protected override void OnStart(string[] args)
        {
            timer.Start();
        }

        protected override void OnStop()
        {
            timer.Stop();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Id.HasValue)
            {
                Report();
            } else
            {
                Connect();
            }
        }

        private void Connect()
        {
            try
            {
                server = new Server("http://localhost", "8080");
                Id = server.Register(machine);
            }
            catch
            {

            }

        }

        private void Report()
        {
            server.CheckIn(Retriever.GetCheckIn(Id.Value));
        }
    }
}
