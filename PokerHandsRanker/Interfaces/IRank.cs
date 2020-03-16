namespace PokerHandsRanker.Interfaces
{
    public interface IRank
    {
        int RankValue { get; set; }
        string Card { get; set; }
        bool? IsBetterRank(IRank other);
    }
}