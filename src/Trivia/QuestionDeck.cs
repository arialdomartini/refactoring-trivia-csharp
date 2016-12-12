using System;
using System.Linq;
using UglyTrivia;

namespace Trivia
{
    public class QuestionDeck
    {
        private readonly Game _game;

        public QuestionDeck(Game game)
        {
            _game = game;
        }

        public void FillQuestions()
        {
            for (var i = 0; i < 50; i++)
            {
                _game.PopQuestions.AddLast("Pop Question " + i);
                _game.ScienceQuestions.AddLast(("Science Question " + i));
                _game.SportsQuestions.AddLast(("Sports Question " + i));
                _game.RockQuestions.AddLast(CreateRockQuestion(i));
            }
        }

        public string CreateRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

        public string CurrentCategoryPlace(int currentPlace)
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

        public void AskQuestionCategory(string category)
        {
            if (category == "Pop")
            {
                Console.WriteLine(_game.PopQuestions.First());
                _game.PopQuestions.RemoveFirst();
            }
            if (category == "Science")
            {
                Console.WriteLine(_game.ScienceQuestions.First());
                _game.ScienceQuestions.RemoveFirst();
            }
            if (category == "Sports")
            {
                Console.WriteLine(_game.SportsQuestions.First());
                _game.SportsQuestions.RemoveFirst();
            }
            if (category == "Rock")
            {
                Console.WriteLine(_game.RockQuestions.First());
                _game.RockQuestions.RemoveFirst();
            }
        }

    }
}