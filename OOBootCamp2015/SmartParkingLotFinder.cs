using System.Linq;

namespace OOBootCamp2015
{
    public class SmartParkingLotFinder :IParkingLotFinder
    {
        public ParkingLot Find(ParkingLot[] parkingLots)
        {
            return parkingLots.OrderByDescending(pl => pl.Space).First();
        }
    }
}