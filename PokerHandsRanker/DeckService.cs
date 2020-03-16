using System;
using System.Collections.Generic;
using PokerHandsRanker.Interfaces;

namespace PokerHandsRanker
{
    public class DeckService : IDeckService
    {
        public Random Rand { get; }

        public DeckService()
        {
            Rand = new Random(DateTime.Now.Millisecond);
        }

        public void DrawCard(ICollection<string> hand, IList<string> deck)
        {
            var cardIndex = Rand.Next(deck.Count);
            hand.Add(deck[cardIndex]);
            deck.RemoveAt(cardIndex);
        }

        public IList<string> InitDeck()
        {
            return new List<string>
            {
                // Clubs
                "AC", "KC", "QC", "JC", "TC", "9C", "8C", "7C", "6C", "5C", "4C", "3C", "2C",
                // Hearts
                "AH", "KH", "QH", "JH", "TH", "9H", "8H", "7H", "6H", "5H", "4H", "3H", "2H",
                // Spades
                "AS", "KS", "QS", "JS", "TS", "9S", "8S", "7S", "6S", "5S", "4S", "3S", "2S",
                // Diamonds
                "AD", "KD", "QD", "JD", "TD", "9D", "8D", "7D", "6D", "5D", "4D", "3D", "2D"
            };
        }
    }
}