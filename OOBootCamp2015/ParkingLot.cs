using System;
using System.Collections.Generic;

namespace OOBootCamp2015
{
    public class ParkingLot : ICanParkingAndStore
    {
        private readonly int count;
        private readonly Dictionary<Ticket,Car> cars = new Dictionary<Ticket, Car>();

        public ParkingLot(int count)
        {
            this.count = count;
        }

        public int Space {
            get { return count - cars.Count; }
        }

        public bool IsFull {
            get { return count == cars.Count; }
        }

        public double Vacancy {
            get
            {
                return ((double)Space)/count;
            }
        }

        public Ticket Store(Car car)
        {
            if (cars.Count == count)
            {
                return null;
            }
            var ticket = new Ticket();
            cars[ticket] = car;
            return ticket;
        }

        public Car Pick(Ticket ticket)
        {
            if (!cars.ContainsKey(ticket)) return null;

            var pickCar = cars[ticket];
            cars.Remove(ticket);
            return pickCar;
        }
    }
}