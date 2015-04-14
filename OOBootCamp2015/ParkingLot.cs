using System.Collections.Generic;

namespace OOBootCamp2015
{
    public class ParkingLot
    {
        private readonly int count;
        private readonly Dictionary<Ticket,Car> cars = new Dictionary<Ticket, Car>();

        public ParkingLot(int count)
        {
            this.count = count;
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