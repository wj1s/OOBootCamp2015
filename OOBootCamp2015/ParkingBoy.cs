using System.Linq;

namespace OOBootCamp2015
{
    public class ParkingBoy
    {
        protected ParkingLot[] parkinglots;
        private readonly IParkingLotFinder parkingLotFinder;

        public ParkingBoy(ParkingLot[] parkinglots, IParkingLotFinder nomalParkingLotFinder)
        {
            this.parkinglots = parkinglots;
            parkingLotFinder = nomalParkingLotFinder;
        }

        public Car Pick(Ticket ticket)
        {
            return parkinglots.Select(parkinglot => parkinglot.Pick(ticket)).FirstOrDefault(car => car != null);
        }

        public Ticket Store(Car car)
        {
            var parkingLot = FindParkingLot();
            return parkingLot != null ? parkingLot.Store(car) : null;
        }

        protected virtual ParkingLot FindParkingLot()
        {
            return parkingLotFinder.Find(parkinglots);
        }
    }
}