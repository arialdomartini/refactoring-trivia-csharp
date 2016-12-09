using System;
using UglyTrivia;

namespace Trivia
{
    public class GameRunner
    {
        private static bool _notAWinner;

        public static void Main(String[] args)
        {
            var rand = new Random();

            Run(rand);
        }

        public static void Run(Random rand)
        {
            Game aGame = new Game();

            aGame.add("Chet");
            aGame.add("Pat");
            aGame.add("Sue");


            do
            {
                aGame.roll(rand.Next(5) + 1);

                if (rand.Next(9) == 7)
                {
                    _notAWinner = aGame.wrongAnswer();
                }
                else
                {
                    _notAWinner = aGame.wasCorrectlyAnswered();
                }
            } while (_notAWinner);
        }
    }

}

