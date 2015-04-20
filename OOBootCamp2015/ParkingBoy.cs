using System.Linq;

namespace OOBootCamp2015
{
    public class ParkingBoy
    {
        protected readonly ParkingLot[] parkinglots;


        public ParkingBoy(ParkingLot[] parkinglots)
        {
            this.parkinglots = parkinglots;
        }

        public virtual Ticket Store(Car car)
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