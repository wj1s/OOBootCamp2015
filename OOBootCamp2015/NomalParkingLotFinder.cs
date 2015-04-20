using System.Linq;

namespace OOBootCamp2015
{
    public class NomalParkingLotFinder : IParkingLotFinder
    {
        public ParkingLot Find(ParkingLot[] parkingLots)
        {
            return parkingLots.FirstOrDefault(pl => !pl.IsFull);
        }
    }
}