using System.Linq;

namespace OOBootCamp2015
{
    public class ParkingBoy : IParkingAndStore
    {
        protected readonly ParkingLot[] parkinglots;

        public ParkingBoy(ParkingLot[] parkinglots)
        {
            this.parkinglots = parkinglots;
        }

        public Ticket Store(Car car)
        {
            var parkingLot = FindParkingLot();

            return parkingLot != null ? parkingLot.Store(car) : null;
        }

        public Car Pick(Ticket ticket)
        {
            return parkinglots.Select(parkinglot => parkinglot.Pick(ticket)).FirstOrDefault(car => car != null);
        }

        public bool IsFull {
            get { return parkinglots.All(p => p.IsFull); }
        }

        public virtual ParkingLot FindParkingLot()
        {
            return parkinglots.FirstOrDefault(pl => !pl.IsFull);
        }
    }
}