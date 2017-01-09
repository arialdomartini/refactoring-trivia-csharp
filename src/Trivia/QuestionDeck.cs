using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class QuestionDeck
    {
        private readonly LinkedList<string> _popQuestions;
        private readonly LinkedList<string> _scienceQuestions;
        private readonly LinkedList<string> _sportsQuestions;
        private readonly LinkedList<string> _rockQuestions;

        public QuestionDeck()
        {
            _popQuestions = new LinkedList<string>();
            _scienceQuestions = new LinkedList<string>();
            _sportsQuestions = new LinkedList<string>();
            _rockQuestions = new LinkedList<string>();
        }

        public void FillQuestions()
        {
            for (var i = 0; i < 50; i++)
            {
                _popQuestions.AddLast(CreateQuestion(i, "Pop"));
                _scienceQuestions.AddLast(CreateQuestion(i, "Science"));
                _sportsQuestions.AddLast(CreateQuestion(i, "Sports"));
                _rockQuestions.AddLast(CreateQuestion(i, "Rock"));
            }
        }

        public string CreateQuestion(int index, string category)
        {
            return category + " Question " + index;
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

        public string AskCategoryQuestion(string category)
        {
            string question = null;

            if (category == "Pop")
            {
                question = _popQuestions.First();
                _popQuestions.RemoveFirst();
            }
            else if (category == "Science")
            {
                question = _scienceQuestions.First();
                _scienceQuestions.RemoveFirst();
            }
            else if (category == "Sports")
            {
                question = _sportsQuestions.First();
                _sportsQuestions.RemoveFirst();
            }
            else if (category == "Rock")
            {
                question = _rockQuestions.First();
                _rockQuestions.RemoveFirst();
            }
            return question;
        }
    }
}