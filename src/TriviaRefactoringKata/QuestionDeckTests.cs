using System;
using Xunit;
using Xunit.Extensions;

namespace Trivia
{
    public class QuestionDeckTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        [InlineData(8)]
        public void CategoryForBoardPlace(Int32 place)
        {
            var deck = new QuestionDeck();

            var category = deck.CurrentCategoryPlace(place);

            Assert.Equal("Pop", category);
        } 
    }
}