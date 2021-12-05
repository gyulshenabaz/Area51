using System;

namespace Area51
{
    public class Agent
    {
        enum Activities { Work, GoToFloor, Leave };

        private string name;
        private Base @base;
        public Floor currentFloor;
        public bool isInBase = true;
        private Random random;
        
        public SecurityLevel SecurityClearance { get; private set; }
        
        public Agent(string name, SecurityLevel securityClearance, Base @base)
        {
            this.name = name;
            this.@base = @base;
            this.currentFloor = @base.floors[0];
            this.random = new Random();
            this.SecurityClearance = securityClearance;
        }
        
        private Activities GetRandomActivity()
        {
            int n = random.Next(10);
            if (n < 1) return Activities.Work;
            if (n < 9) return Activities.GoToFloor;
            return Activities.Leave;
        }

        public async void InvadeBuilding()
        {
            Console.WriteLine($"{this} entered the building");
            
            while (isInBase)
            {
                var nextActivity = GetRandomActivity();
                
                switch (nextActivity)
                {
                    case Activities.GoToFloor:
                        Floor destinationFloor = @base.GetRandomFloor();
                        this.@base.elevator.CallToFloor(destinationFloor, @base);
                        this.@base.elevator.Enter(this, destinationFloor);
                        break;
                    case Activities.Leave:
                        Console.WriteLine($"Agent with name {this.name} is leaving the building");
                        isInBase = false;
                        break;
                }
            }
        }
        
        public override string ToString()
        {
            return $"{name}";
        }
    }
}