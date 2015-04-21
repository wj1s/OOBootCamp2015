using System.Linq;

namespace OOBootCamp2015
{
    public class ParkingBoy : BoyBase, ICanParkingAndStore
    {

        public ParkingBoy(ParkingLot[] parkingAndStores): base(parkingAndStores)
        {
        }

        protected override ICanParkingAndStore FindCanStore()
        {
            return parkingAndStores.FirstOrDefault(pl => !pl.IsFull);
        }
    }
}