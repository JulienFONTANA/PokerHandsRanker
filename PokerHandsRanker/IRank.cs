﻿namespace PokerHandsRanker
{
    public interface IRank
    {
        int RankValue { get; set; }
        string Card { get; set; }
        bool? IsBetterRank(Rank other);
    }
}