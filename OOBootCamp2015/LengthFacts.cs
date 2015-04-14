using Xunit;

namespace OOBootCamp2015
{
    public class LengthFacts
    {
        [Fact]
        public void should_equal_given_two_length_given_value_same()
        {
            Assert.Equal(new Length(1, Unit.M), new Length(1, Unit.M));
        }

        [Fact]
        public void should_not_equal_given_two_length_given_value_not_same()
        {
            Assert.NotEqual(new Length(1, Unit.M), new Length(2, Unit.M));
        }

        [Fact]
        public void should_equal_given_two_length_given_value_same_and_unit_same()
        {
            Assert.Equal(new Length(1, Unit.M), new Length(1, Unit.M));
        }

        [Fact]
        public void should_equal_given_two_length_given_value_same_and_unit_sam1e()
        {
            Assert.Equal(new Length(1, Unit.M), new Length(100, Unit.CM));
        }
    }

    public class Unit
    {
        public static Unit M = new Unit(100);
        public static Unit CM = new Unit(1);

        private Unit(int atom)
        {
            Atom = atom;
        }

        private int Atom { get; set; }

        public int TransFor(int targetValue, Unit targetUnit)
        {
            return targetValue*targetUnit.Atom/Atom;
        }
    }

    public class Length
    {
        public Length(int value, Unit unit)
        {
            Value = value;
            Unit = unit;
        }

        public Unit Unit { get; private set; }

        public int Value { get; private set; }

        public override bool Equals(object obj)
        {
            var o = (Length) obj;
            return Value == Unit.TransFor(o.Value, o.Unit) ;
        }
    }
}