using Autofac;
using Battleships.Business.AllocationService;
using Battleships.Business.BattleService;
using Battleships.Models;

namespace Battleships.Presenter.Ioc
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SeaBattleService>().As<IBattleService<SeaBattle, SeaBattleSettings>>();
            builder.RegisterType<ShipPlacementService>().As<ITargetPlacementService<SeaBattle>>();
        }
    }
}
