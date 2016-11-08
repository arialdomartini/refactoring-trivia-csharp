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

        public String CurrentCategoryPlace(Int32 currentPlace)
        {
            if (currentPlace == 0) return "Pop";
            if (currentPlace == 4) return "Pop";
            if (currentPlace == 8) return "Pop";
            if (currentPlace == 1) return "Science";
            if (currentPlace == 5) return "Science";
            if (currentPlace == 9) return "Science";
            if (currentPlace == 2) return "Sports";
            if (currentPlace == 6) return "Sports";
            if (currentPlace == 10) return "Sports";
            return "Rock";
        }
    }
}