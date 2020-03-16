using Ninject.Modules;

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
        }
    }
}
