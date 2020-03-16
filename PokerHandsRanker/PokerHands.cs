using System;
using System.Collections.Generic;

namespace PokerHandsRanker
{
    public class PokerHands : IPokerHands
    {
        private Random Rand { get; }
        private IRankService RankService { get; }
        private IHandPrinterService HandPrinterService { get; }

        private IList<string> _deck;

        public PokerHands(IRankService rankService,
            IHandPrinterService handPrinterService)
        {
            Rand = new Random();
            RankService = rankService;
            HandPrinterService = handPrinterService;
        }

        public void Rank()
        {
            var gameOver = false;
            while (!gameOver)
            {
                var handP1 = new List<string>();
                var handP2 = new List<string>();
                
                InitDeck();
                while (handP1.Count != 5 && handP2.Count != 5)
                {
                    DrawCard(handP1, _deck);
                    DrawCard(handP2, _deck);
                }
                var rankHandP1 = RankHand(handP1);
                var rankHandP2 = RankHand(handP2);

                HandPrinterService.PrintHand(1, handP1, rankHandP1);
                HandPrinterService.PrintHand(2, handP2, rankHandP2);

                var winner = RankHands(handP1, handP2);

                Console.WriteLine(winner != 0 ? $"Player {winner} won this round !" : "It's a tie !");
                Console.WriteLine("Play another hand ? Or press 'q' to quit...");
                if (Console.ReadKey().KeyChar.Equals('q'))
                {
                    gameOver = true;
                }
                Console.Clear();
            }
        }

        private int RankHands(List<string> handP1, List<string> handP2)
        {
            var rankHandP1 = RankHand(handP1);
            var rankHandP2 = RankHand(handP2);

            var p1Won = rankHandP1.IsBetterRank(rankHandP2);

            if (p1Won != null)
            {
                return p1Won.Value ? 1 : 2;
            }

            return 0;
        }

        private Rank RankHand(List<string> hand)
        {
            return RankService.GetRankFromHand(hand);
        }

        private void DrawCard(ICollection<string> hand, IList<string> deck)
        {
            var cardIndex = Rand.Next(deck.Count);
            hand.Add(deck[cardIndex]);
            deck.RemoveAt(cardIndex);
        }

        private void InitDeck()
        {
            _deck = new List<string>
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