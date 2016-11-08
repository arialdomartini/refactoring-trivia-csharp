using System;
using System.Collections.Generic;
using System.Linq;
using UglyTrivia;

namespace Trivia
{
    public class QuestionDeck
    {
        readonly Game game;
        readonly LinkedList<String> popQuestions;

        public QuestionDeck(Game game)
        {
            this.game = game;
            popQuestions = this.game.PopQuestions;
        }

        public String createRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

        public void FillQuestions()
        {
            for (int i = 0; i < 50; i++)
            {
                popQuestions.AddLast("Pop Question " + i);
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

        public void AskCategoryQuestion(String category)
        {
            if (category == "Pop")
            {
                Console.WriteLine(popQuestions.First());
                popQuestions.RemoveFirst();
            }
            if (category == "Science")
            {
                Console.WriteLine(game.ScienceQuestions.First());
                game.ScienceQuestions.RemoveFirst();
            }
            if (category == "Sports")
            {
                Console.WriteLine(game.SportsQuestions.First());
                game.SportsQuestions.RemoveFirst();
            }
            if (category == "Rock")
            {
                Console.WriteLine(game.RockQuestions.First());
                game.RockQuestions.RemoveFirst();
            }
        }
    }
}