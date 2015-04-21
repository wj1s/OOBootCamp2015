using System.Linq;

namespace OOBootCamp2015
{
    public class ParkingBoy : BoyBase<ParkingLot>, ICanParkingAndStore
    {
        public ParkingBoy(ParkingLot[] parkingAndStores): base(parkingAndStores)
        {
        }

        protected override ICanParkingAndStore FindCanStore()
        {
            return parkingAndStores.FirstOrDefault(pl => !pl.IsFull);
        }

        protected override string GetReportHead()
        {
            return "B";
        }
    }
}