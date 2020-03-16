using NFluent;
using NUnit.Framework;
using PokerHandsRanker;

namespace PokerHandsRankerTests
{
    public class RankTests
    {
        [Test]
        public void Should_Have_Rank1_Better_Than_Rank2_When_Higher()
        {
            var rank1 = new Rank(2, "AC");
            var rank2 = new Rank(1, "TC");

            Check.That(rank1.IsBetterRank(rank2));
        }

        [Test]
        public void Should_Have_Rank2_Better_Than_Rank1_When_Lower()
        {
            var rank1 = new Rank(2, "AC");
            var rank2 = new Rank(4, "QS");

            Check.That(rank2.IsBetterRank(rank1));
        }

        [Test]
        public void Should_Have_Rank1_Better_Than_Rank2_When_Same_Rank_But_Higher_Card()
        {
            var rank1 = new Rank(1, "AC");
            var rank2 = new Rank(1, "QS");

            Check.That(rank1.IsBetterRank(rank2));
        }

        [Test]
        public void Should_Have_A_Tie_When_Ranks_Are_The_Same()
        {
            var rank1 = new Rank(1, "AC");
            var rank2 = new Rank(1, "AS");

            Check.That(rank2.IsBetterRank(rank1)).Equals(null);
        }
    }
}
