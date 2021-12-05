using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;

namespace Area51
{
    public class Elevator
    {
        private static int MS_PER_FLOOR = 1000;
        
        enum ElevatorState { Free, Occupied };
        
        private Floor currentFloor;

        private ElevatorState state;
        
        public Elevator(Floor baseFloor)
        {
            this.currentFloor = baseFloor;
            this.state = ElevatorState.Free;
        }
        
        public void Enter(Agent agent, Floor floor) {
            if (floor.MinimumSecurityClearance > agent.SecurityClearance) {
                Console.WriteLine($"Agent {agent} with security access: {agent.SecurityClearance} doesn't have permission to access {floor} floor.");
                return;
            }

            Console.WriteLine(($"Agent {agent} is on floor {floor}"));
            agent.currentFloor = floor;
        }
        
        public void CallToFloor(Floor floor, Base @base)
        {
            if (state == ElevatorState.Free)
            {
                state = ElevatorState.Occupied;
                Thread.Sleep(@base.GetFloors(currentFloor, floor) * MS_PER_FLOOR);
                this.currentFloor = floor;
                state = ElevatorState.Free;
            }
        }
    }
}