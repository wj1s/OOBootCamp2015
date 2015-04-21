using System.Linq;

namespace OOBootCamp2015
{
    public class SuperParkingBoy : BoyBase<ParkingLot>, ICanParkingAndStore
    {
        public SuperParkingBoy(ParkingLot[] parkingLots) : base(parkingLots)
        {
        }

        protected override ICanParkingAndStore FindCanStore()
        {
            return parkingAndStores.OrderByDescending(p => p.Vacancy).First();
        }

        protected override string GetReportHead()
        {
            return "B";
        }
    }
}