using System.Collections.Generic;
using PokerHandsRanker.Interfaces;

namespace PokerHandsRanker
{
    public class HandRankerService : IHandRankerService
    {
        private readonly IRankService _rankService;

        public HandRankerService(IRankService rankService)
        {
            _rankService = rankService;
        }

        public int RankHands(IList<string> handP1, IList<string> handP2)
        {
            var rankHandP1 = RankHand(handP1);
            var rankHandP2 = RankHand(handP2);

            var p1Won = rankHandP1.IsBetterRank(rankHandP2);

            if (p1Won != null)
            {
                return p1Won.Value ? 1 : 2;
            }

            return 0;
        }

        public IRank RankHand(IList<string> hand)
        {
            return _rankService.GetRankFromHand(hand);
        }
    }
}