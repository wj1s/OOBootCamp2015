using Xunit;

namespace OOBootCamp2015
{
    public class ReportFacts
    {
        [Fact]
        public void should_generate_report()
        {
            var manager = new Manager(new ICanParkingAndStore[0]);
            var report = manager.Report();
            var result = @"
M 0 0
";
            Assert.Equal(result,report);
        }

        [Fact]
        public void should_generate_report1()
        {
            var manager = new Manager(new ICanParkingAndStore[]{new ParkingLot(1)});
            var report = manager.Report();
            var result = @"
M 1 1
    P 1 1
";
            Assert.Equal(result,report);
        }

        [Fact]
        public void should_generate_report2()
        {
            var parkingLot = new ParkingLot(1);
            parkingLot.Store(new Car());

            var manager = new Manager(new ICanParkingAndStore[]{parkingLot,new ParkingLot(2)});
            var report = manager.Report();
            var result = @"
M 2 3
    P 0 1
    P 2 2
";
            Assert.Equal(result,report);
        }

        [Fact]
        public void should_generate_report3()
        {
            var manager = new Manager(new ICanParkingAndStore[]{new ParkingBoy(new ParkingLot[0])});
            var report = manager.Report();
            var result = @"
M 0 0
    B 0 0
";
            Assert.Equal(result,report);
        }

        [Fact]
        public void should_generate_report4()
        {
            var manager = new Manager(new ICanParkingAndStore[] {new ParkingBoy(new ParkingLot[0]), new ParkingLot(2)});
            var report = manager.Report();
            var result = @"
M 2 2
    B 0 0
    P 2 2
";
            Assert.Equal(result,report);
        }

        [Fact]
        public void should_generate_report5()
        {
            var manager = new Manager(new ICanParkingAndStore[] {new ParkingBoy(new[]{new ParkingLot(3)}), new ParkingLot(2)});
            var report = manager.Report();
            var result = @"
M 5 5
    B 3 3
        P 3 3
    P 2 2
";
            Assert.Equal(result,report);
        }
        
        [Fact]
        public void should_generate_report6()
        {
            var parkingLot = new ParkingLot(10);
            parkingLot.Store(new Car());
            parkingLot.Store(new Car());
            parkingLot.Store(new Car());
            parkingLot.Store(new Car());
            parkingLot.Store(new Car());
            parkingLot.Store(new Car());
            parkingLot.Store(new Car());
            parkingLot.Store(new Car());


            var parkingLot2 = new ParkingLot(5);
            parkingLot2.Store(new Car());
            parkingLot2.Store(new Car());
            parkingLot2.Store(new Car());

            var parkingLot3 = new ParkingLot(3);
            parkingLot3.Store(new Car());
            parkingLot3.Store(new Car());
            parkingLot3.Store(new Car());

            var parkingLot4 = new ParkingLot(2);
            parkingLot4.Store(new Car());

            var parkingBoy = new ParkingBoy(new ParkingLot[]{parkingLot2});
            var parkingBoy2 = new ParkingBoy(new ParkingLot[] { parkingLot3,parkingLot4 });
            var manager = new Manager(new ICanParkingAndStore[] {parkingLot,parkingBoy,parkingBoy2});
            var report = manager.Report();
            var result = @"
M 5 20
    P 2 10
    B 2 5
        P 2 5
    B 1 5
        P 0 3
        P 1 2
";
            Assert.Equal(result,report);
        }
    }
}