using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Shuffle.Tests
{
    [TestFixture]
    public class ShuffleTests
    {
        private string[] values = {
            "Ace",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "Jack",
            "Queen",
            "King"
        };

        private string[] suits =
        {
            "Hearts",
            "Diamonds",
            "Clubs",
            "Spades"
        };

        private List<object> _deck;

        public void InitializeDeck()
        {
            _deck = new List<object>();

            foreach (var suit in suits)
            {
                foreach (var value in values)
                {
                    _deck.Add($"{value} of {suit}");
                }
            }

            _deck.Add("Black Joker");
            _deck.Add("Red Joker");
        }


        [Test(Description = "Using 100 standard 54-card decks, each shuffled between 1 and 10 times, none of them should equal another, or the initial, unshuffled, deck.")]
        public void StandardDeckTest()
        {
            InitializeDeck();

            var deckOfDecks = new List<IEnumerable<object>> {_deck};

            for (var i = 1; i <= 100; i++)
            {
                var newDeck = Shuffle.RiffleAndCut(_deck, i);

                foreach (var deck in deckOfDecks)
                {
                    Assert.False(newDeck.SequenceEqual(deck));
                }

                deckOfDecks.Add(newDeck);
            }
        }

        [Test(Description = "Using ten 10-card decks, each shuffled between 1 and 10 times, none of them should equal another, or the initial, unshuffled, deck.")]
        public void TenCardDeckTest()
        {
            var tenCardDeck = new List<object> {
                "One",
                "Two",
                "Three",
                "Four",
                "Five",
                "Six",
                "Seven",
                "Eight",
                "Nine",
                "Ten"
            };

            var deckOfDecks = new List<IEnumerable<object>> { tenCardDeck };

            for (var i = 1; i <= 10; i++)
            {
                var newDeck = Shuffle.RiffleAndCut(tenCardDeck, i);

                foreach (var deck in deckOfDecks)
                {
                    Assert.False(newDeck.SequenceEqual(deck));
                }

                deckOfDecks.Add(newDeck);
            }

        }
    }
}
