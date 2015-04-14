using Xunit;

namespace OOBootCamp2015
{
    public class ParkingBoyFacts
    {
        [Fact]
        public void should_park_one_car_and_pick_by_parking_lot()
        {
            var parkinglot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(new[] {parkinglot});
            var car = new Car();

            var ticket = parkingBoy.Store(car);

            Assert.Same(car, parkinglot.Pick(ticket));
        }

        [Fact]
        public void should_park_more_than_one_car_and_pick_by_parking_lot()
        {
            var parkingLot = new ParkingLot(2);
            var parkingBoy = new ParkingBoy(new[] {parkingLot});
            var firstCar = new Car();
            var secondCar = new Car();

            var ticketForFirstCar = parkingBoy.Store(firstCar);
            var ticketForSecondCar = parkingBoy.Store(secondCar);

            Assert.Same(firstCar, parkingLot.Pick(ticketForFirstCar));
            Assert.Same(secondCar, parkingLot.Pick(ticketForSecondCar));
        }

        [Fact]
        public void should_park_2_car_in_2_one_place_parking_lot()
        {
            var firstParkingLot = new ParkingLot(1);
            var secondParkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(new[] {firstParkingLot, secondParkingLot});
            var firstCar = new Car();
            var secondCar = new Car();

            var ticketForFirstCar = parkingBoy.Store(firstCar);
            var ticketForSecondCar = parkingBoy.Store(secondCar);

            Assert.Same(firstCar, firstParkingLot.Pick(ticketForFirstCar));
            Assert.Same(secondCar, secondParkingLot.Pick(ticketForSecondCar));
        }

        [Fact]
        public void should_not_park_when_all_parkingLot_is_full()
        {
            var firstParkingLot = new ParkingLot(1);
            var secondParkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(new[] {firstParkingLot, secondParkingLot});
            parkingBoy.Store(new Car());
            parkingBoy.Store(new Car());

            Assert.Null(parkingBoy.Store(new Car()));
        }

        [Fact]
        public void should_pick_a_car_by_ticket()
        {
            var parkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(new[] {parkingLot});
            var car = new Car();

            var ticket = parkingBoy.Store(car);

            Assert.Same(car, parkingBoy.Pick(ticket));
        }

        [Fact]
        public void should_not_pick_a_car_more_than_one_time_with_one_ticket()
        {
            var parkingBoy = new ParkingBoy(new[] {new ParkingLot(1)});
            var ticket = parkingBoy.Store(new Car());
            parkingBoy.Pick(ticket);

            var car = parkingBoy.Pick(ticket);

            Assert.Null(car);
        }

        [Fact]
        public void should_pick_a_car_by_from_more_than_one_parking_lot()
        {
            var parkingBoy = new ParkingBoy(new[] { new ParkingLot(1), new ParkingLot(1) });
            var firstCar = new Car();
            var secondCar = new Car();

            var ticketForFirstCar = parkingBoy.Store(firstCar);
            var ticketForSecondCar = parkingBoy.Store(secondCar);

            Assert.Same(firstCar, parkingBoy.Pick(ticketForFirstCar));
            Assert.Same(secondCar, parkingBoy.Pick(ticketForSecondCar));
        }
    }
}