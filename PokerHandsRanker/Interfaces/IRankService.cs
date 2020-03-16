using System.Collections.Generic;

namespace PokerHandsRanker.Interfaces
{
    public interface IRankService
    {
        IRank GetRankFromHand(IList<string> hand);
    }
}