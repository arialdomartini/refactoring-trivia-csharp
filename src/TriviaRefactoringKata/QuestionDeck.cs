using System;
using System.Collections.Generic;
using System.Linq;
using UglyTrivia;

namespace Trivia
{
    public class QuestionDeck
    {
        readonly LinkedList<String> popQuestions;
        readonly LinkedList<String> scienceQuestions;
        readonly LinkedList<String> sportsQuestions;
        readonly LinkedList<String> rockQuestions;

        public QuestionDeck(Game game)
        {
            popQuestions = game.PopQuestions;
            scienceQuestions = game.ScienceQuestions;
            sportsQuestions = game.SportsQuestions;
            rockQuestions = game.RockQuestions;
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
                scienceQuestions.AddLast(("Science Question " + i));
                sportsQuestions.AddLast(("Sports Question " + i));
                rockQuestions.AddLast(this.createRockQuestion(i));
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
                Console.WriteLine(scienceQuestions.First());
                scienceQuestions.RemoveFirst();
            }
            if (category == "Sports")
            {
                Console.WriteLine(sportsQuestions.First());
                sportsQuestions.RemoveFirst();
            }
            if (category == "Rock")
            {
                Console.WriteLine(rockQuestions.First());
                rockQuestions.RemoveFirst();
            }
        }
    }
}