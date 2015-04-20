using Xunit;

namespace OOBootCamp2015
{
    public class SuperParkingBoyFacts
    {
        [Fact]
        public void should_park_one_car_and_pick_by_parking_lot()
        {
            var parkinglot = new ParkingLot(1);
            var superParkingBoy = new SuperParkingBoy(new[] {parkinglot});
            var car = new Car();

            var ticket = superParkingBoy.Store(car);

            Assert.Same(car, parkinglot.Pick(ticket));
        }

        [Fact]
        public void should_park_more_than_one_car_and_pick_by_parking_lot()
        {
            var parkingLot = new ParkingLot(2);
            var superParkingBoy = new SuperParkingBoy(new[] {parkingLot});
            var firstCar = new Car();
            var secondCar = new Car();

            var ticketForFirstCar = superParkingBoy.Store(firstCar);
            var ticketForSecondCar = superParkingBoy.Store(secondCar);

            Assert.Same(firstCar, parkingLot.Pick(ticketForFirstCar));
            Assert.Same(secondCar, parkingLot.Pick(ticketForSecondCar));
        }

        [Fact]
        public void should_park_in_second_parking_lot_with_more_space()
        {
            var firstParkingLot = new ParkingLot(5);//3/5
            firstParkingLot.Store(new Car());
            firstParkingLot.Store(new Car());
            firstParkingLot.Store(new Car());
            var secondParkingLot = new ParkingLot(2);//1/2
            secondParkingLot.Store(new Car());

            var superParkingBoy = new SuperParkingBoy(new[] {firstParkingLot, secondParkingLot});
            var car = new Car();

            var ticket = superParkingBoy.Store(car);

            Assert.Same(car, secondParkingLot.Pick(ticket));
        }


        [Fact]
        public void should_not_park_when_all_parkingLot_is_full()
        {
            var firstParkingLot = new ParkingLot(1);
            var secondParkingLot = new ParkingLot(1);
            var superParkingBoy = new SuperParkingBoy(new[] {firstParkingLot, secondParkingLot});
            superParkingBoy.Store(new Car());
            superParkingBoy.Store(new Car());

            Assert.Null(superParkingBoy.Store(new Car()));
        }

        [Fact]
        public void should_pick_a_car_by_ticket()
        {
            var parkingLot = new ParkingLot(1);
            var superParkingBoy = new SuperParkingBoy(new[] {parkingLot});
            var car = new Car();

            var ticket = superParkingBoy.Store(car);

            Assert.Same(car, superParkingBoy.Pick(ticket));
        }

        [Fact]
        public void should_not_pick_a_car_more_than_one_time_with_one_ticket()
        {
            var superParkingBoy = new SuperParkingBoy(new[] {new ParkingLot(1)});
            var ticket = superParkingBoy.Store(new Car());
            superParkingBoy.Pick(ticket);

            var car = superParkingBoy.Pick(ticket);

            Assert.Null(car);
        }

        [Fact]
        public void should_pick_a_car_by_from_more_than_one_parking_lot()
        {
            var superParkingBoy = new SuperParkingBoy(new[] { new ParkingLot(1), new ParkingLot(1) });
            var firstCar = new Car();
            var secondCar = new Car();

            var ticketForFirstCar = superParkingBoy.Store(firstCar);
            var ticketForSecondCar = superParkingBoy.Store(secondCar);

            Assert.Same(firstCar, superParkingBoy.Pick(ticketForFirstCar));
            Assert.Same(secondCar, superParkingBoy.Pick(ticketForSecondCar));
        }
    }
}