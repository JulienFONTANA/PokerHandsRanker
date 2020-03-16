using System.Collections.Generic;

namespace PokerHandsRanker.Interfaces
{
    public interface IHandRankerService
    {
        int RankHands(IList<string> handP1, IList<string> handP2);
        IRank RankHand(IList<string> hand);
    }
}