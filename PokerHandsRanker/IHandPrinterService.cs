using System.Collections.Generic;

namespace PokerHandsRanker
{
    public interface IHandPrinterService
    {
        void PrintHand(int player, IEnumerable<string> hand, IRank rankHand);
    }
}