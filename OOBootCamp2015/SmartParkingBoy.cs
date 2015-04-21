using System.Linq;

namespace OOBootCamp2015
{
    public class SmartParkingBoy : BoyBase<ParkingLot>, ICanParkingAndStore
    {
        public SmartParkingBoy(ParkingLot[] parkingLots) : base(parkingLots)
        {
        }

        protected override ICanParkingAndStore FindCanStore()
        {
            return parkingAndStores.OrderByDescending(pl => pl.Space).First();
        }

        protected override string GetReportHead()
        {
            return "B";
        }
    }
}