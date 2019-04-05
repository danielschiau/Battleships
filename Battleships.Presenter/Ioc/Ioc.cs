using Autofac;

namespace Battleships.Presenter.Ioc
{
    public static class Ioc
    {
        private static IContainer _instance;

        public static IContainer Instance => _instance ?? (_instance = ConfigureContainer());

        private static IContainer ConfigureContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule<PresenterModule>();
            containerBuilder.RegisterModule<GameEngineModule>();

            return containerBuilder.Build();
        }
    }
}
