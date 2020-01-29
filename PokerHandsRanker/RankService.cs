using System.Collections.Generic;
using System.Linq;

namespace PokerHandsRanker
{
    public class RankService
    {
        public Rank GetRankFromHand(List<string> hand)
        {
            var rank = HasMultipleSameValueCards(hand); // 2x, 3x, 4x, 2-2 and 2-3 ?
            var isStraight = IsStraight(hand);
            var isFlush = IsFlush(hand);

            if (!ReferenceEquals(isStraight, null) && !ReferenceEquals(isFlush, null))
            {
                return isStraight[0].Equals('A') ? new Rank(10, isStraight) : new Rank(9, isStraight);
            }

            if (rank != null && (rank.RankValue == 8 || rank.RankValue == 7))
            {
                return rank; // Four of a kind or Full House
            }

            if (!ReferenceEquals(isFlush, null))
            {
                return new Rank(6, isFlush); // Flush
            }

            if (!ReferenceEquals(isStraight, null))
            {
                return new Rank(5, isStraight); // Straight
            }

            if (rank != null && (rank.RankValue == 4 || rank.RankValue == 3 || rank.RankValue == 2))
            {
                return rank; // Three of a kind, or one or two pairs
            }

            return new Rank(1, FindHighestCard(hand));
        }

        private static Rank HasMultipleSameValueCards(IReadOnlyCollection<string> hand)
        {
            Rank rank = null;
            var distinctCardValues = hand.Select(card => Rank.RankCards.FirstOrDefault(c => c.Key == card[0]).Key)
                .Distinct().ToList();

            if (distinctCardValues.Count == 5)
            {
                return null;
            }

            foreach (var value in distinctCardValues)
            {
                var count = hand.Count(c => c[0] == value);
                if (count != 1)
                {
                    if (ReferenceEquals(rank, null))
                    {
                        var handRank = count == 2 ? 2   // Pair 
                            : count == 3 ? 4            // Three of a kind
                            : count == 4 ? 8            // Four of a kind
                            : 0;                        // Can't happen, you cheated.
                        rank = new Rank(handRank, hand.FirstOrDefault(c => c[0] == value));
                    }
                    else // Already a Pair or a Three of a kind
                    {
                        var handRank = count == 2 ? 2   // Pair 
                            : count == 3 ? 4            // Three of a kind
                            : 0;
                        if (handRank == 2 && rank.RankValue == 2)
                        {
                            rank.RankValue = 3; // Two pairs
                        }

                        // 2 cards + 3 cards
                        if (handRank == 4 && rank.RankValue == 2
                            || handRank == 2 && rank.RankValue == 4)
                        {
                            rank.RankValue = 7; // Full House
                        }
                    }
                }
            }

            return rank;
        }

        private static string IsStraight(IList<string> hand)
        {
            var cardValues = hand.Select(card => Rank.RankCards.FirstOrDefault(c => c.Key == card[0]).Value).ToList();

            var checkedValue = 0;
            foreach (var value in cardValues.OrderBy(x => x))
            {
                if (checkedValue == 0)
                {
                    checkedValue = value;
                }
                else
                {
                    if (checkedValue + 1 == value)
                    {
                        checkedValue++;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return FindHighestCard(hand);
        }

        private static string IsFlush(IList<string> hand)
        {
            var color = '_';
            foreach (var card in hand)
            {
                if (color == '_')
                {
                    color = card[1];
                }
                else if (color != card[1])
                {
                    return null;
                }
            }

            return FindHighestCard(hand);
        }

        private static string FindHighestCard(IEnumerable<string> hand)
        {
            var highCard = "";
            foreach (var card in hand)
            {
                if (highCard == "")
                {
                    highCard = card;
                }
                else
                {
                    if (Rank.RankCards.FirstOrDefault(c => c.Key == highCard[0]).Value < Rank.RankCards.FirstOrDefault(c => c.Key == card[0]).Value)
                    {
                        highCard = card;
                    }
                }
            }

            return highCard;
        }
    }
}