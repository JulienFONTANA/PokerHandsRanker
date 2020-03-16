using System.Collections.Generic;

namespace PokerHandsRanker.Interfaces
{
    public interface IRankService
    {
        Rank GetRankFromHand(List<string> hand);
    }
}