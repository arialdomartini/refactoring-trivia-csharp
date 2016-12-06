using System;
using System.IO;
using System.Linq;
using Trivia;
using Xunit;

namespace TriviaTest
{
    public class DummyTest : IDisposable
    {
        private TextWriter _originalOut;

        public DummyTest()
        {
            _originalOut = Console.Out;
        }

        public void Dispose()
        {
            Console.SetOut(_originalOut);
        }

        [Fact]
        public void write_program_output_to_file()
        {
            using (var writer = File.CreateText("output.txt"))
            {
                Console.SetOut(writer);
                foreach (var i in Enumerable.Range(0, 1000))
                {
                    GameRunner.Main(null);
                }
            }
        }
    }
}