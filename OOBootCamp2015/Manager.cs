using System.Linq;

namespace OOBootCamp2015
{
    public class Manager : BoyBase<ICanParkingAndStore>
    {
        public Manager(ICanParkingAndStore[] parkingAndStores) : base(parkingAndStores)
        {
        }

        protected override ICanParkingAndStore FindCanStore()
        {
            return parkingAndStores.FirstOrDefault(pl => !pl.IsFull);
        }

        public string Report(int prefixCount = 0)
        {
            var prefix = "";
            for (int i = 0; i < prefixCount; i++)
            {
                prefix += "    ";
            }
            string report = "";
            foreach (ICanParkingAndStore store in parkingAndStores)
                report = report + (store.Report(prefixCount + 1));
            return "\r\nM " + Space + " " + Count + "\r\n"+report;
        }
    }
}