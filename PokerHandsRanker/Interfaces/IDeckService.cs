using System.Collections.Generic;

namespace PokerHandsRanker.Interfaces
{
    public interface IDeckService
    {
        void DrawCard(ICollection<string> hand, IList<string> deck);
        IList<string> InitDeck();
    }
}