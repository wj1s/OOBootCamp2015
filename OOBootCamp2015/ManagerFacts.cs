using Xunit;

namespace OOBootCamp2015
{
    public class ManagerFacts
    {
        [Fact]
        public void should_park_one_car_and_pick_by_parking_lot()
        {
            var parkinglot = new ParkingLot(1);
            var manager = new Manager(new[] {parkinglot});
            var car = new Car();

            var ticket = manager.Store(car);

            Assert.Same(car, parkinglot.Pick(ticket));
        }

        [Fact]
        public void should_park_more_than_one_car_and_pick_by_parking_lot()
        {
            var parkingLot = new ParkingLot(2);
            var manager = new Manager(new[] {parkingLot});
            var firstCar = new Car();
            var secondCar = new Car();

            var ticketForFirstCar = manager.Store(firstCar);
            var ticketForSecondCar = manager.Store(secondCar);

            Assert.Same(firstCar, parkingLot.Pick(ticketForFirstCar));
            Assert.Same(secondCar, parkingLot.Pick(ticketForSecondCar));
        }

        [Fact]
        public void should_park_2_car_in_2_one_place_parking_lot()
        {
            var firstParkingLot = new ParkingLot(1);
            var secondParkingLot = new ParkingLot(1);
            var manager = new Manager(new[] {firstParkingLot, secondParkingLot});
            var firstCar = new Car();
            var secondCar = new Car();

            var ticketForFirstCar = manager.Store(firstCar);
            var ticketForSecondCar = manager.Store(secondCar);

            Assert.Same(firstCar, firstParkingLot.Pick(ticketForFirstCar));
            Assert.Same(secondCar, secondParkingLot.Pick(ticketForSecondCar));
        }

        [Fact]
        public void should_not_park_when_all_parkingLot_is_full()
        {
            var firstParkingLot = new ParkingLot(1);
            var secondParkingLot = new ParkingLot(1);
            var manager = new Manager(new[] {firstParkingLot, secondParkingLot});
            manager.Store(new Car());
            manager.Store(new Car());

            Assert.Null(manager.Store(new Car()));
        }

        [Fact]
        public void should_pick_a_car_by_ticket()
        {
            var parkingLot = new ParkingLot(1);
            var manager = new Manager(new[] {parkingLot});
            var car = new Car();

            var ticket = manager.Store(car);

            Assert.Same(car, manager.Pick(ticket));
        }

        [Fact]
        public void should_not_pick_a_car_more_than_one_time_with_one_ticket()
        {
            var manager = new Manager(new[] {new ParkingLot(1)});
            var ticket = manager.Store(new Car());
            manager.Pick(ticket);

            var car = manager.Pick(ticket);

            Assert.Null(car);
        }

        [Fact]
        public void should_pick_a_car_by_from_more_than_one_parking_lot()
        {
            var manager = new Manager(new[] { new ParkingLot(1), new ParkingLot(1) });
            var firstCar = new Car();
            var secondCar = new Car();

            var ticketForFirstCar = manager.Store(firstCar);
            var ticketForSecondCar = manager.Store(secondCar);

            Assert.Same(firstCar, manager.Pick(ticketForFirstCar));
            Assert.Same(secondCar, manager.Pick(ticketForSecondCar));
        }

        [Fact]
        public void should_pick_a_car_and_store_a_car_by_a_boy()
        {
            var manager = new Manager(new [] { new ParkingBoy(new[] {new ParkingLot(1)}) });
            var car = new Car();

            var ticket = manager.Store(car);

            Assert.Same(car, manager.Pick(ticket));
        }

        [Fact]
        public void should_pick_a_car_and_store_a_car_by_a_boy_and_a_parking_lot()
        {
            var manager = new Manager(new IParkingAndStore[] { new ParkingBoy(new[] {new ParkingLot(1)}),new ParkingLot(1)});
            var firstCar = new Car();
            var secondCar = new Car();

            var ticketForFirstCar = manager.Store(firstCar);
            var ticketForSecondCar = manager.Store(secondCar);

            Assert.Same(firstCar, manager.Pick(ticketForFirstCar));
            Assert.Same(secondCar, manager.Pick(ticketForSecondCar));
        }
    }
}