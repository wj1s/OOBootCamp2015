namespace OOBootCamp2015
{
    public interface IParkingAndStore
    {
        Ticket Store(Car car);
        Car Pick(Ticket ticket);
        bool IsFull { get; }
    }
}