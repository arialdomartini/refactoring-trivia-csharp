using System;
using Xunit;

namespace TriviaTest
{
    public class DummyTest
    {
        [Fact]
        public void should_pass()
        {
            Assert.Equal("foo", "foo");
        }
    }
}