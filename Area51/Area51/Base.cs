using System;
using System.Collections.Generic;
using System.Linq;

namespace Area51
{
    public class Base
    {
        private Random random = new Random();
        public List<Floor> floors { get; set; }
        public Elevator elevator { get; set; }
        
        public Base(List<Floor> floors, Elevator elevator)
        {
            this.elevator = elevator;
            this.floors = floors;
        }
        
        public Floor GetRandomFloor() {
            return floors[random.Next(0, floors.Count)];
        }
        
        public int GetFloors(Floor floorA, Floor floorB)
        {
            int indexA = floors.FindIndex(f=>f.Equals(floorA));
            int indexB = floors.FindIndex(f=>f.Equals(floorB));

            if (indexA > indexB ) return GetFloors(floorB, floorA);

            int numberOfFloors = 0;

            for ( int i = indexA; i <= indexB; i++ )
            {
                numberOfFloors++;
            }

            return numberOfFloors;
        }
    }
}