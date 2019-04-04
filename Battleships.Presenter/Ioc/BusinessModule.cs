using Autofac;
using Battleships.GameEngine.Games;
using Battleships.GameEngine.Worlds;

namespace Battleships.Presenter.Ioc
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BattleshipGame>().As<IGamePlay>();
            builder.RegisterType<SeaWorld>().As<IWorld>();
        }
    }
}
