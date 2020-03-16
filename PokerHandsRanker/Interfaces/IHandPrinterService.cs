using System.Collections.Generic;

namespace PokerHandsRanker.Interfaces
{
    public interface IHandPrinterService
    {
        void PrintHand(int player, IEnumerable<string> hand, IRank rankHand);
    }
}