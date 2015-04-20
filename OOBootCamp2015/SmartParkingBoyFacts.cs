using Xunit;

namespace OOBootCamp2015
{
    public class SmartParkingBoyFacts
    {
        [Fact]
        public void should_park_one_car_and_pick_by_parking_lot()
        {
            var parkinglot = new ParkingLot(1);
            var smartParkingBoy = new ParkingBoy(new[] {parkinglot}, new SmartParkingLotFinder());
            var car = new Car();

            var ticket = smartParkingBoy.Store(car);

            Assert.Same(car, parkinglot.Pick(ticket));
        }

        [Fact]
        public void should_park_more_than_one_car_and_pick_by_parking_lot()
        {
            var parkingLot = new ParkingLot(2);
            var smartParkingBoy = new ParkingBoy(new[] {parkingLot}, new SmartParkingLotFinder());
            var firstCar = new Car();
            var secondCar = new Car();

            var ticketForFirstCar = smartParkingBoy.Store(firstCar);
            var ticketForSecondCar = smartParkingBoy.Store(secondCar);

            Assert.Same(firstCar, parkingLot.Pick(ticketForFirstCar));
            Assert.Same(secondCar, parkingLot.Pick(ticketForSecondCar));
        }

        [Fact]
        public void should_park_in_second_parking_lot_with_more_space()
        {
            var firstParkingLot = new ParkingLot(1);
            var secondParkingLot = new ParkingLot(2);
            var smartParkingBoy = new ParkingBoy(new[] {firstParkingLot, secondParkingLot}, new SmartParkingLotFinder());
            var car = new Car();

            var ticketForFirstCar = smartParkingBoy.Store(car);
            Assert.Same(car, secondParkingLot.Pick(ticketForFirstCar));

            secondParkingLot.Store(new Car());

            var ticketForSecondCar = smartParkingBoy.Store(car);
            Assert.Same(car, firstParkingLot.Pick(ticketForSecondCar));
        }


        [Fact]
        public void should_not_park_when_all_parkingLot_is_full()
        {
            var firstParkingLot = new ParkingLot(1);
            var secondParkingLot = new ParkingLot(1);
            var smartParkingBoy = new ParkingBoy(new[] {firstParkingLot, secondParkingLot}, new SmartParkingLotFinder());
            smartParkingBoy.Store(new Car());
            smartParkingBoy.Store(new Car());

            Assert.Null(smartParkingBoy.Store(new Car()));
        }

        [Fact]
        public void should_pick_a_car_by_ticket()
        {
            var parkingLot = new ParkingLot(1);
            var smartParkingBoy = new ParkingBoy(new[] {parkingLot}, new SmartParkingLotFinder());
            var car = new Car();

            var ticket = smartParkingBoy.Store(car);

            Assert.Same(car, smartParkingBoy.Pick(ticket));
        }

        [Fact]
        public void should_not_pick_a_car_more_than_one_time_with_one_ticket()
        {
            var smartParkingBoy = new ParkingBoy(new[] {new ParkingLot(1)}, new SmartParkingLotFinder());
            var ticket = smartParkingBoy.Store(new Car());
            smartParkingBoy.Pick(ticket);

            var car = smartParkingBoy.Pick(ticket);

            Assert.Null(car);
        }

        [Fact]
        public void should_pick_a_car_by_from_more_than_one_parking_lot()
        {
            var smartParkingBoy = new ParkingBoy(new[] { new ParkingLot(1), new ParkingLot(1) }, new SmartParkingLotFinder());
            var firstCar = new Car();
            var secondCar = new Car();

            var ticketForFirstCar = smartParkingBoy.Store(firstCar);
            var ticketForSecondCar = smartParkingBoy.Store(secondCar);

            Assert.Same(firstCar, smartParkingBoy.Pick(ticketForFirstCar));
            Assert.Same(secondCar, smartParkingBoy.Pick(ticketForSecondCar));
        }
    }
}