using System.Linq;

namespace OOBootCamp2015
{
    public class Manager
    {
        protected readonly IParkingAndStore[] parkinglots;

        public Manager(IParkingAndStore[] parkinglots)
        {
            this.parkinglots = parkinglots;
        }

        public Ticket Store(Car car)
        {
            var parkingLot = parkinglots.FirstOrDefault(pl => !pl.IsFull);

            return parkingLot != null ? parkingLot.Store(car) : null;
        }

        public Car Pick(Ticket ticket)
        {
            return parkinglots.Select(parkinglot => parkinglot.Pick(ticket)).FirstOrDefault(car => car != null);
        }
    }
}