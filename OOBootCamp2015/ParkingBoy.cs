using System.Linq;

namespace OOBootCamp2015
{
    public class ParkingBoy
    {
        private readonly ParkingLot[] parkinglots;


        public ParkingBoy(ParkingLot[] parkinglots)
        {
            this.parkinglots = parkinglots;
        }

        public Ticket Store(Car car)
        {
            return parkinglots.Select(parkinglot => parkinglot.Store(car)).FirstOrDefault(ticket => ticket != null);
        }

        public Car Pick(Ticket ticket)
        {
            return parkinglots.Select(parkinglot => parkinglot.Pick(ticket)).FirstOrDefault(car => car != null);
        }
    }
}