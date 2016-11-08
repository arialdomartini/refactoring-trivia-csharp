using System;
using UglyTrivia;

namespace Trivia
{
    public class QuestionDeck
    {
        public String createRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

        public void FillQuestions(Game game)
        {
            for (int i = 0; i < 50; i++)
            {
                game.PopQuestions.AddLast("Pop Question " + i);
                game.ScienceQuestions.AddLast(("Science Question " + i));
                game.SportsQuestions.AddLast(("Sports Question " + i));
                game.RockQuestions.AddLast(this.createRockQuestion(i));
            }
        }
    }
}