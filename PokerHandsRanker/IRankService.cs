using System.Collections.Generic;

namespace PokerHandsRanker
{
    public interface IRankService
    {
        Rank GetRankFromHand(List<string> hand);
    }
}