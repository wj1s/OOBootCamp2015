using System.Linq;

namespace OOBootCamp2015
{
    public class SuperParkingBoy : ParkingBoy
    {
        public SuperParkingBoy(ParkingLot[] parkingLots) : base(parkingLots)
        {
        }

        public override ParkingLot FindParkingLot()
        {
            return parkinglots.OrderByDescending(p => p.Vacancy).First();
        }
    }
}