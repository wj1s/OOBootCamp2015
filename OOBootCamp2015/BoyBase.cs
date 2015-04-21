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

        protected abstract ICanParkingAndStore FindCanStore();
    }
}