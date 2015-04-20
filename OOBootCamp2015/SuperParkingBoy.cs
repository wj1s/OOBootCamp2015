using System.Linq;

namespace OOBootCamp2015
{
    public class SuperParkingBoy : ParkingBoy
    {
        public SuperParkingBoy(ParkingLot[] parkingLots) : base(parkingLots)
        {
        }

        public override Ticket Store(Car car)
        {
            return parkinglots.OrderByDescending(p => p.Vacancy).First().Store(car);
        }
    }
}