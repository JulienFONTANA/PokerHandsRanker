using NFluent;
using NSubstitute;
using NUnit.Framework;
using PokerHandsRanker;
using PokerHandsRanker.Interfaces;
using System.Collections.Generic;

namespace PokerHandsRankerTests
{
    public class HandRankerServiceTests
    {
        private IHandRankerService _handRankerService;
        private IRankService _rankService;

        [SetUp]
        public void SetUp()
        {
            _rankService = Substitute.For<IRankService>();
            _handRankerService = new HandRankerService(_rankService);
        }

        [Test]
        public void Should_Call_IRankService_When_Ranking_Hands()
        {
            var hand = new List<string> { "3C", "3H", "3D", "AC", "DC" };

            _rankService.GetRankFromHand(hand).Returns(new Rank(4, "3C"));
            _handRankerService.RankHand(new List<string>());

            Check.That(_rankService.Received(1));
        }

        [Test]
        public void Should_Have_Player1_Win_If_His_Hand_Is_Better()
        {
            var handP1 = new List<string> { "3C", "3H", "3D", "AC", "DC" }; // 3 of a kind
            var handP2 = new List<string> { "4S", "4H", "AS", "QC", "JS" }; // Pair

            _rankService.GetRankFromHand(handP1).Returns(new Rank(4, "3C"));
            _rankService.GetRankFromHand(handP2).Returns(new Rank(2, "4S"));
            var bestHand = _handRankerService.RankHands(handP1, handP2);

            Check.That(bestHand).IsEqualTo(1);
        }


        [Test]
        public void Should_Have_Player2_Win_If_His_Hand_Is_Better()
        {
            var handP1 = new List<string> { "4S", "4H", "AS", "QC", "JS" }; // Pair
            var handP2 = new List<string> { "3C", "3H", "3D", "AC", "DC" }; // 3 of a kind

            _rankService.GetRankFromHand(handP1).Returns(new Rank(2, "4S"));
            _rankService.GetRankFromHand(handP2).Returns(new Rank(4, "3C"));
            var bestHand = _handRankerService.RankHands(handP1, handP2);

            Check.That(bestHand).IsEqualTo(2);
        }


        [Test]
        public void Should_Have_A_Tie_If_Hands_Are_Equal()
        {
            var handP1 = new List<string> { "4C", "4D", "AC", "QS", "JD" }; // Pair
            var handP2 = new List<string> { "4S", "4H", "AS", "QC", "JS" }; // Pair

            _rankService.GetRankFromHand(handP1).Returns(new Rank(2, "4C"));
            _rankService.GetRankFromHand(handP2).Returns(new Rank(2, "4S"));
            var bestHand = _handRankerService.RankHands(handP1, handP2);

            Check.That(bestHand).IsEqualTo(0);
        }
    }
}
