using System.Linq;

namespace OOBootCamp2015
{
    public abstract class BoyBase<T> where T : ICanParkingAndStore
    {
        protected T[] parkingAndStores;

        protected BoyBase(T[] parkingAndStores)
        {
            this.parkingAndStores = parkingAndStores;
        }

        public Ticket Store(Car car)
        {
            var parkingLot = FindCanStore();
            return parkingLot != null ? parkingLot.Store(car) : null;
        }

        public Car Pick(Ticket ticket)
        {
            return parkingAndStores.Select(parkinglot => parkinglot.Pick(ticket)).FirstOrDefault(car => car != null);
        }

        public bool IsFull
        {
            get { return parkingAndStores.All(p => p.IsFull); }
        }

        public int Count {
            get
            {
                return parkingAndStores.Sum(parkingAndStore => parkingAndStore.Count);
            } 
        }

        public int Space {
            get
            {
                return parkingAndStores.Sum(parkingAndStore => parkingAndStore.Space);
            }
        }

        public string Report(int prefixCount = 0)
        {
            string report = parkingAndStores.Aggregate("", (current, store) => current + (store.Report(prefixCount + 1)));
            return (prefixCount == 0? "\r\n": prefixCount.Prefix()) + GetReportHead() + " " + Space + " " + Count + "\r\n" + report;
        }

        protected abstract ICanParkingAndStore FindCanStore();

        protected abstract string GetReportHead();
        
    }
}