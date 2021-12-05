using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Area51
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Floor> floors = new List<Floor>()
            {
                new Floor("G", SecurityLevel.Confidential),
                new Floor("S", SecurityLevel.Secret),
                new Floor("T1",SecurityLevel.TopSecret),
                new Floor("T2",SecurityLevel.TopSecret)
            };
            
            var tasks = new List<Task>();
            
            Elevator elevator = new Elevator(floors[0]);
            
            Base @base = new Base(floors, elevator);
            
            Random random = new Random();
            
            for (int i = 0; i < 2; i++) {
                
                SecurityLevel securityLevel = (SecurityLevel)random.Next(3);

                Agent a = new Agent ("00" + i, securityLevel, @base);

                tasks.Add(Task.Run(a.InvadeBuilding));
            }

            Task.WhenAll(tasks).Wait();
        }
    }
}
