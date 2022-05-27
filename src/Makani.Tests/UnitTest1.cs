using Bunit;

namespace Makani.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var expected = 1;
            var actual = 1;
            Assert.Equal(expected, actual);
        }
    }
}