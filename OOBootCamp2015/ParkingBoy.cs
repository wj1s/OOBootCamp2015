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

        public string Report(int prefixCount)
        {
            var prefix = Prefix(prefixCount);
            string report = parkingAndStores.Aggregate("",
                (current, canParkingAndStore) => current + (canParkingAndStore.Report(prefixCount + 1)));
            return prefix + "B " + Space + " " + Count + "\r\n" + report;
        }

        private static string Prefix(int prefixCount)
        {
            string prefix = "";
            for (int i = 0; i < prefixCount; i++)
            {
                prefix += "    ";
            }
            return prefix;
        }
    }
}