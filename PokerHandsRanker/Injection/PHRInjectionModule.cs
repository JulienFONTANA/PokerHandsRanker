using Ninject.Modules;
using PokerHandsRanker.Interfaces;

namespace PokerHandsRanker.Injection
{
    public class PhrInjectionModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPokerHands>().To<PokerHands>();
            Bind<IRank>().To<IRank>();
            Bind<IRankService>().To<RankService>();
            Bind<IHandPrinterService>().To<HandPrinterService>();
            Bind<IDeckService>().To<DeckService>();
            Bind<IHandRankerService>().To<HandRankerService>();
        }
    }
}
