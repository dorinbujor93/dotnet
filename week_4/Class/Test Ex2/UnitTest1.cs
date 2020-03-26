using Ex2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Test_Ex2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConstructedAsSpecified()
        {
            var date = new BusinessDate(2014, 3, 28);
            date.Day.Should().Be(28);
            date.Month.Should().Be(3);
            date.Year.Should().Be(2014);
        }

        [TestMethod]
        public void BusinessDateIsEqualToItself()
        {
            var date = new BusinessDate(2015, 10, 06);
            Equality(date, date, true);
        }

        [TestMethod]
        public void CanBeParsedFromIso8601DateString()
        {
           
            BusinessDate.ParseFromIso8601String("2015-06-10").Should().Be(new BusinessDate(2015, 6, 10));
        }

        public void Equality(BusinessDate left, BusinessDate right, bool areEqual)
        {
            left.Equals(right).Should().Be(areEqual);
            (left == right).Should().Be(areEqual);
            (left != right).Should().Be(!areEqual);
            (left.GetHashCode() == right.GetHashCode()).Should().Be(areEqual);
        }
    }
}
