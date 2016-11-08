using Xunit;

namespace Trivia
{
    public class QuestionDeckTests
    {
        [Fact]
        public void CategoryForBoardPlace()
        {
            var deck = new QuestionDeck();

            var category = deck.CurrentCategoryPlace(0);

            Assert.Equal("Pop", category);
        } 
    }
}