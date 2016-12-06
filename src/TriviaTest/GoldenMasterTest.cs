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
        private const string ActualOutput = "output.txt";
        private const string GoldenMaster = "../../golden-master.txt";

        public GoldenMasterTest()
        {
            _originalOut = Console.Out;
        }

        public void Dispose()
        {
            Console.SetOut(_originalOut);
        }

        [Fact]
        public void golden_master()
        {
            RunTheProgram(seed: 99, outputFile: ActualOutput, times: 1000);

            var actual = File.ReadAllText(ActualOutput);
            var goldenMaster = File.ReadAllText(GoldenMaster);

            Assert.Equal(goldenMaster, actual);
        }

        [Fact]
        public void checks_wheter_the_output_is_deterministic()
        {
            RunTheProgram(seed: 99, outputFile: "output1.txt", times: 1000);

            RunTheProgram(seed: 99, outputFile: "output2.txt", times: 1000);

            var actual1 = File.ReadAllText("output1.txt");
            var actual2 = File.ReadAllText("output2.txt");
            Assert.Equal(actual1, actual2);
        }

        private static void RunTheProgram(int seed, string outputFile, int times)
        {
            int times1;
            using (var writer = File.CreateText(outputFile))
            {
                Console.SetOut(writer);
                foreach (var i in Enumerable.Range(0, times))
                {
                    GameRunner.Run(new Random(seed));
                }
            }
        }
    }
}