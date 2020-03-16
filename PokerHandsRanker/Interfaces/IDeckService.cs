using System.Collections.Generic;

namespace PokerHandsRanker
{
    public interface IDeckService
    {
        void DrawCard(ICollection<string> hand, IList<string> deck);
        List<string> InitDeck();
    }
}