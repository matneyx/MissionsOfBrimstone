using System.Collections.Generic;
using System.Linq;

namespace Shuffle
{
    public static class Shuffle
    {
        public static void Cut(IList<object> deck, out List<object> leftDeck, out List<object> rightDeck)
        {
            leftDeck = deck.Take((deck.Count() / 2) + RNG.Between(deck.Count() / 10 * -1, deck.Count() / 10)).ToList<object>();

            var tempLeft = leftDeck;

            rightDeck = deck.Where(card => !tempLeft.Contains(card)).ToList<object>();
        }

        public static IList<object> CutAndStack(IList<object> deck)
        {
            var leftDeck = deck.Take(RNG.Between((int) 0, deck.Count())).ToList<object>();

            var tempLeft = leftDeck;

            var rightDeck = deck.Where(card => !tempLeft.Contains(card)).ToList<object>();

            rightDeck.AddRange(leftDeck);

            return rightDeck;
        }

        public static IList<object> RiffleAndCut(IList<object> deck, int numberOfShuffles = 1)
        {
            while (true)
            {
                var shuffledDeck = new List<object>();

                List<object> leftDeck, rightDeck;
                Cut(deck, out leftDeck, out rightDeck);

                var smallerDeckCount = leftDeck.Count() < rightDeck.Count() ? leftDeck.Count() : rightDeck.Count();

                for (var i = 0; i < smallerDeckCount; i++)
                {
                    for (var j = 0; leftDeck.Any() && j <= RNG.Between((int) 0, (int) 2); j++)
                    {
                        shuffledDeck.Add(leftDeck.ElementAt(0));
                        leftDeck.RemoveAt(0);
                    }

                    for (var j = 0; rightDeck.Any() && j <= RNG.Between((int) 0, (int) 2); j++)
                    {
                        shuffledDeck.Add(rightDeck.ElementAt(0));
                        rightDeck.RemoveAt(0);
                    }
                }

                if (leftDeck.Count > 0) shuffledDeck.AddRange(leftDeck);
                if (rightDeck.Count > 0) shuffledDeck.AddRange(rightDeck);

                if (numberOfShuffles <= 1) return CutAndStack(shuffledDeck);

                deck = CutAndStack(shuffledDeck);
                numberOfShuffles = numberOfShuffles - 1;
            }
        }
    }
}