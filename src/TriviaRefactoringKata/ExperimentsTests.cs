using System;
using System.IO;
using Xunit;

namespace Trivia
{
    public class ExperimentsTests
    {
        [Fact]
        public void Blah()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            GameRunner.Main(null);
            Assert.Equal("", writer.ToString());
        }
    }
}