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
            using (var writer = File.CreateText("output1.txt"))
            {
                Console.SetOut(writer);
                for (int i = 0; i < 1; i++)
                {
                    var seed = i;
                    GameRunner.Run(new Random(seed));
                }
            }
        }
    }
}