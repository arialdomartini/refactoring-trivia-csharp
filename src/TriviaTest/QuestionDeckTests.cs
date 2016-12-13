using Trivia;
using Xunit;

namespace TriviaTest
{
    public class QuestionDeckTests
    {
        [Theory]
        [InlineData(0, "Pop")]
        [InlineData(4, "Pop")]
        [InlineData(8, "Pop")]
        [InlineData(1, "Science")]
        [InlineData(5, "Science")]
        [InlineData(9, "Science")]
        [InlineData(2, "Sports")]
        [InlineData(6, "Sports")]
        [InlineData(10, "Sports")]
        [InlineData(3, "Rock")]
        [InlineData(7, "Rock")]
        [InlineData(11, "Rock")]
        public void CategoryForBoardPlace(int place, string expected)
        {
            var deck = new QuestionDeck();

            var category = deck.CurrentCategoryPlace(place);

            Assert.Equal(expected, category);
        }

        [Theory]
        [InlineData(12)]
        [InlineData(1234)]
        [InlineData(int.MaxValue)]
        [InlineData(-1)]
        public void CategoryForOutOfBoardPlace(int place)
        {
            var deck = new QuestionDeck();

            var category = deck.CurrentCategoryPlace(place);

            Assert.Equal("Rock", category);
        }
    }
}