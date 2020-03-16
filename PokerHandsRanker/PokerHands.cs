using System;
using System.Collections.Generic;
using PokerHandsRanker.Interfaces;

namespace PokerHandsRanker
{
    public class PokerHands : IPokerHands
    {
        private readonly IDeckService _deckService;
        private readonly IHandPrinterService _handPrinterService;
        private readonly IHandRankerService _handRankerService;

        public PokerHands(IHandPrinterService handPrinterService, 
            IDeckService deckService, 
            IHandRankerService handRankerService)
        {
            _handPrinterService = handPrinterService;
            _deckService = deckService;
            _handRankerService = handRankerService;
        }

        public void Rank()
        {
            var gameOver = false;
            while (!gameOver)
            {
                var handP1 = new List<string>();
                var handP2 = new List<string>();
                
                var deck = _deckService.InitDeck();
                while (handP1.Count != 5 && handP2.Count != 5)
                {
                    _deckService.DrawCard(handP1, deck);
                    _deckService.DrawCard(handP2, deck);
                }
                var rankHandP1 = _handRankerService.RankHand(handP1);
                var rankHandP2 = _handRankerService.RankHand(handP2);

                _handPrinterService.PrintHand(1, handP1, rankHandP1);
                _handPrinterService.PrintHand(2, handP2, rankHandP2);

                var winner = _handRankerService.RankHands(handP1, handP2);

                Console.WriteLine(winner != 0 ? $"Player {winner} won this round !" : "It's a tie !");
                Console.WriteLine("Play another hand ? Or press 'q' to quit...");
                if (Console.ReadKey().KeyChar.Equals('q'))
                {
                    gameOver = true;
                }
                Console.Clear();
            }
        }
    }
}