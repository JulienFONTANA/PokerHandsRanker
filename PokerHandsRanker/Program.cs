using System;
using Ninject;
using PokerHandsRanker.Injection;
using PokerHandsRanker.Interfaces;

namespace PokerHandsRanker
{
    public class Program
    {
        public static void Main()
        {
            // TODO :
            // 1. Tests
            // 2. Proper hand name display
            //      ie : Full House Name Display -> (K K K 4 4 is Kings over Fours)
            // 3. Stop the screen from flickering + have not too many input at once
            // 4. Readme (this should be higher up the list)

            Console.ForegroundColor = ConsoleColor.White;
            var kernel = new StandardKernel(new PhrInjectionModule());
            var service = kernel.Get<IPokerHands>();
            service.Rank();
        }
    }
}
