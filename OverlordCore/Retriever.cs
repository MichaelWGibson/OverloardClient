using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace OverlordCore
{
    public static class Retriever
    {
        public static Machine GetMachine()
        {
            return new Machine()
            {
                Name = Environment.MachineName,
                Lab = "Test LAB",
                MacAddress = NetworkHelper.GetMacAddress(),
                IpAddress = NetworkHelper.GetLocalIPAddress(),
                OS = "Windows"
            };
        }

        public static IEnumerable<Entry> GetEntries()
        {
            return Process.GetProcesses()
                .Where(p => p.MainWindowHandle.ToInt32() > 0)
                .Select(p => new Entry { ImageName = p.ProcessName, MemUsage = p.WorkingSet64 })
                .Distinct()
                .ToList();
        }

        public static CheckIn GetCheckIn(int machineId)
        {
            return new CheckIn()
            {
                MacAddress = NetworkHelper.GetMacAddress(),
                UserName = Environment.UserName,
                MachineID = machineId,
                Entries = GetEntries()
            };
        }
    }
}
