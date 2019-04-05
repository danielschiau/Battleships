using Autofac;
using Battleships.GameEngine.Games;
using Battleships.GameEngine.Worlds;

namespace Battleships.Presenter.Ioc
{
    public class GameEngineModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BattleshipGame>().As<IGame>().WithParameter("settings", null);
            builder.RegisterType<SeaWorld>().As<IWorld>();
        }
    }
}
