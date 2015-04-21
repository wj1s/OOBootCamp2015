using System.Linq;

namespace OOBootCamp2015
{
    public class SuperParkingBoy : BoyBase, ICanParkingAndStore
    {
        protected readonly ParkingLot[] parkinglots;

        public SuperParkingBoy(ParkingLot[] parkingLots) : base(parkingLots)
        {
            parkinglots = parkingLots;
        }

        protected override ICanParkingAndStore FindCanStore()
        {
            return parkinglots.OrderByDescending(p => p.Vacancy).First();
        }
    }
}