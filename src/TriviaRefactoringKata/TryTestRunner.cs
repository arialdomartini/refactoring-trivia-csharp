using Xunit;

namespace Trivia
{
    public class TryTestRunner
    {
        [Fact]
        public void TryMe()
        {
            Assert.Equal("b", "b");
        }
    }
}