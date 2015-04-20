using System.Linq;

namespace OOBootCamp2015
{
    public class SmartParkingBoy : ParkingBoy
    {
        public SmartParkingBoy(ParkingLot[] parkingLots) : base(parkingLots)
        {
        }

        public override ParkingLot FindParkingLot()
        {
            return parkinglots.OrderByDescending(pl => pl.Space).First();
        }
    }
}