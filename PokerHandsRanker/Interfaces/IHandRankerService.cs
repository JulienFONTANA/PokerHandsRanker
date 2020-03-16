using System.Collections.Generic;

namespace PokerHandsRanker
{
    public interface IHandRankerService
    {
        int RankHands(List<string> handP1, List<string> handP2);
        Rank RankHand(List<string> hand);
    }
}