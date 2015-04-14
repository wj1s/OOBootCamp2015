using Xunit;

namespace OOBootCamp2015
{
    public class ParkingLotFacts
    {
        [Fact]
        public void should_park_and_pick_a_car()
        {
            var parkingLot = new ParkingLot(1);
            var car = new Car();

            Assert.Same(car, parkingLot.Pick(parkingLot.Store(car)));
        }

        [Fact]
        public void should_park_and_pick_more_than_one_car()
        {
            var parkingLot = new ParkingLot(2);
            var firstCar = new Car();
            var secondCar = new Car();

            var ticketForFirstCar = parkingLot.Store(firstCar);
            var ticketForSecondCar = parkingLot.Store(secondCar);

            Assert.Same(firstCar, parkingLot.Pick(ticketForFirstCar));
            Assert.Same(secondCar, parkingLot.Pick(ticketForSecondCar));
        }

        [Fact]
        public void should_not_when_parking_lot_is_full()
        {
            var parkingLot = new ParkingLot(1);
            parkingLot.Store(new Car());

            Assert.Null(parkingLot.Store(new Car()));
        }

        [Fact]
        public void should_not_pick_car_when_ticket_already_used()
        {
            var parkingLot = new ParkingLot(1);
            var ticket = parkingLot.Store(new Car());
            parkingLot.Pick(ticket);

            var car = parkingLot.Pick(ticket);
            Assert.Null(car);
        }

        [Fact]
        public void should_can_store_when_pick_one_car_after_full()
        {
            var parkingLot = new ParkingLot(1);
            parkingLot.Pick(parkingLot.Store(new Car()));

            var car = new Car();
            var ticket = parkingLot.Store(car);

            Assert.Same(car, parkingLot.Pick(ticket));
        }
    }
}