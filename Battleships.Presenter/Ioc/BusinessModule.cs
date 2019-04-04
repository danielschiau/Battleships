using System.Collections.Generic;
using Autofac;
using Battleships.Business.AllocationService;
using Battleships.Business.BattleService;
using Battleships.Business.MapService;
using Battleships.Models;

namespace Battleships.Presenter.Ioc
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SeaBattleService>().As<IBattleService<SeaBattle, SeaBattleSettings>>();
            builder.RegisterType<ShipPlacementService>().As<ITargetPlacementService<List<Ship>>>();
            builder.RegisterType<SeaMapService>().As<IBattleMapService>();
        }
    }
}
