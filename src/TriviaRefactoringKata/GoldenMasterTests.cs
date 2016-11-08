using System;
using System.IO;
using Xunit;

namespace Trivia
{
    public class GoldenMasterTests
    {
        const String ActualFile = "output1.txt";
        const String GoldenMasterFile = @"..\..\golden-master.txt";

        [Fact]
        public void TriviaGame()
        {
            RunOneThousandGames();
            var expected = ReadGoldenMaster();
            var actual = ReadLastOutput();
            Assert.Equal(expected, actual);
        }

        static String ReadLastOutput()
        {
            return File.ReadAllText(ActualFile);
        }

        static String ReadGoldenMaster()
        {
            return File.ReadAllText(GoldenMasterFile);
        }

        static void RunOneThousandGames()
        {
            var original = Console.Out;
            try
            {
                using (var writer = File.CreateText(ActualFile))
                {
                    Console.SetOut(writer);
                    for (var i = 0; i < 1000; i++)
                    {
                        var seed = 34728 + 17 * i;
                        GameRunner.Run(new Random(seed));
                    }
                }
            }
            finally
            {
               Console.SetOut(original); 
            }
        }
    }
}