using System.Collections.Generic;
using System.Linq;
using PokerHandsRanker.Interfaces;

namespace PokerHandsRanker
{
    public class Rank : IRank
    {
        public int RankValue { get; set; }
        public string Card { get; set; }

        public Rank(int rankValue, string card)
        {
            RankValue = rankValue;
            Card = card;
        }

        public bool? IsBetterRank(IRank other)
        {
            if (other.RankValue < RankValue)
            {
                return true;
            }
            if (other.RankValue > RankValue)
            {
                return false;
            }

            // Rank Values are the same, then test the card
            var thisCardValue = RankCards.FirstOrDefault(c => c.Key == Card[0]).Value;
            var otherCardValue = RankCards.FirstOrDefault(c => c.Key == other.Card[0]).Value;
            if (otherCardValue == thisCardValue)
            {
                return null; // Tie
            }
            return otherCardValue < thisCardValue;
        }

        public static readonly IDictionary<int, string> RankNames = new Dictionary<int, string>
        {
            {1, "High Card"},
            {2, "Pair"},
            {3, "Two Pairs"},
            {4, "Three of a Kind"},
            {5, "Straight"},
            {6, "Flush"},
            {7, "Full House"},
            {8, "Four of a Kind"},
            {9, "Straight Flush"},
            {10, "Royal Flush"},
        };

        public static readonly IDictionary<char, int> RankCards = new Dictionary<char, int>
        {
            {'2', 1},
            {'3', 2},
            {'4', 3},
            {'5', 4},
            {'6', 5},
            {'7', 6},
            {'8', 7},
            {'9', 8},
            {'T', 9},
            {'J', 10},
            {'Q', 11},
            {'K', 12},
            {'A', 13},
        };
    }
}