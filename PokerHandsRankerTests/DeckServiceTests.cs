using System.Collections.Generic;
using NFluent;
using NUnit.Framework;
using PokerHandsRanker;
using PokerHandsRanker.Interfaces;

namespace PokerHandsRankerTests
{
    public class DeckServiceTests
    {
        private IDeckService _deckService;

        [SetUp]
        public void SetUp()
        {
            _deckService = new DeckService();
        }

        [Test]
        public void Should_Have_Complete_52_Cards_Deck_After_Initialisation()
        {
            var deck = _deckService.InitDeck();
            Check.That(deck.Count).IsEqualTo(52);
            Check.That(deck).ContainsNoDuplicateItem();
        }

        [Test]
        public void Should_Draw_A_Card_From_Deck_And_Place_It_In_Hand()
        {
            var deck = _deckService.InitDeck();
            var hand = new List<string>();

            _deckService.DrawCard(hand, deck);
            _deckService.DrawCard(hand, deck);
            _deckService.DrawCard(hand, deck);
            _deckService.DrawCard(hand, deck);
            _deckService.DrawCard(hand, deck);

            Check.That(deck.Count).IsEqualTo(47);
            Check.That(hand.Count).IsEqualTo(5);
            Check.That(hand).ContainsNoDuplicateItem();
        }
    }
}
