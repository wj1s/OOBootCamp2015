namespace OOBootCamp2015
{
    public interface ICanParkingAndStore
    {
        Ticket Store(Car car);
        Car Pick(Ticket ticket);
        bool IsFull { get; }
    }
}