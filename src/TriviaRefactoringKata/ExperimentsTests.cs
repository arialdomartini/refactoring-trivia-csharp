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
            RunOneThousandGames();
        }

        static void RunOneThousandGames()
        {
            using (var writer = File.CreateText("output1.txt"))
            {
                Console.SetOut(writer);
                for (var i = 0; i < 1000; i++)
                {
                    var seed = 34728 + 17*i;
                    GameRunner.Run(new Random(seed));
                }
            }
        }
    }
}