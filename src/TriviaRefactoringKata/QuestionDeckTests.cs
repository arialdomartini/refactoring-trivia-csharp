using System;
using Xunit;
using Xunit.Extensions;

namespace Trivia
{
    public class QuestionDeckTests
    {
        [Theory]
        [InlineData(0, "Pop")]
        [InlineData(4, "Pop")]
        [InlineData(8, "Pop")]
        public void CategoryForBoardPlace(Int32 place, String expected)
        {
            var deck = new QuestionDeck();

            var category = deck.CurrentCategoryPlace(place);

            Assert.Equal(expected, category);
        } 
    }
}