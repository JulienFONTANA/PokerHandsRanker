using System;
using System.Collections.Generic;
using System.Linq;
using PokerHandsRanker.Interfaces;

namespace PokerHandsRanker
{
    public class HandPrinterService : IHandPrinterService
    {
        public void PrintHand(int player, IEnumerable<string> hand, IRank rankHand)
        {
            Console.WriteLine($"Hand of player {player} is : ");
            foreach (var card in hand)
            {
                PrintCard(card);
            }

            Console.Write($" - {Rank.RankNames.FirstOrDefault(r => r.Key == rankHand.RankValue).Value} with {rankHand.Card}");

            Console.WriteLine();
        }

        private static void PrintCard(string card)
        {
            Console.ForegroundColor = ConsoleColor.Black;

            switch (card[1])
            {
                case 'C':
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                case 'H':
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case 'S':
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case 'D':
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    break;
            }
            Console.Write(card);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
        }
    }
}