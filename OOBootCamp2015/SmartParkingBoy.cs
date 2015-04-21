using System.Linq;

namespace OOBootCamp2015
{
    public class SmartParkingBoy : BoyBase, ICanParkingAndStore
    {
        protected readonly ParkingLot[] parkinglots;

        public SmartParkingBoy(ParkingLot[] parkingLots) : base(parkingLots)
        {
            parkinglots = parkingLots;
        }

        protected override ICanParkingAndStore FindCanStore()
        {
            return parkinglots.OrderByDescending(pl => pl.Space).First();
        }
    }
}