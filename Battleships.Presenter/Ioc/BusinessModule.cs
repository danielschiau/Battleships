﻿using Autofac;
using Battleships.GameEngine.Games;
using Battleships.GameEngine.Maps;

namespace Battleships.Presenter.Ioc
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BattleshipGame>().As<IGamePlay>();
            builder.RegisterType<SeaMap>().As<IMap>();
        }
    }
}
