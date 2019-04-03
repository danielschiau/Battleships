﻿using Autofac;

namespace Battleships.Presenter.Ioc
{
    public class IocSetup
    {
        public static IContainer Instance;

        public static void RegisterModules()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule<PresenterModule>();

            Instance = containerBuilder.Build();
        }
    }
}