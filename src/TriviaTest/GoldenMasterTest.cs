using System;
using System.IO;
using System.Linq;
using Trivia;
using Xunit;

namespace TriviaTest
{
    public class GoldenMasterTest : IDisposable
    {
        private readonly TextWriter _originalOut;

        public GoldenMasterTest()
        {
            _originalOut = Console.Out;
        }

        public void Dispose()
        {
            Console.SetOut(_originalOut);
        }

        [Fact]
        public void checks_wheter_the_output_is_deterministic()
        {
            RunTheProgram(outputFile: "output1.txt", times: 1000);

            RunTheProgram(outputFile: "output2.txt", times: 1000);

            var actual1 = File.ReadAllText("output1.txt");
            var actual2 = File.ReadAllText("output2.txt");
            Assert.Equal(actual1, actual2);
        }

        private static void RunTheProgram(string outputFile, int times)
        {
            using (var writer = File.CreateText(outputFile))
            {
                Console.SetOut(writer);
                foreach (var i in Enumerable.Range(0, times))
                {
                    GameRunner.Main(null);
                }
            }
        }
    }
}