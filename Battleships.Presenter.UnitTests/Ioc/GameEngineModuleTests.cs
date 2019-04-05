using System;
using Autofac;
using Autofac.Builder;
using Battleships.GameEngine.Games;
using Battleships.GameEngine.Worlds;
using Battleships.Presenter.Ioc;
using NUnit.Framework;

namespace Battleships.Presenter.UnitTests.Ioc
{
    public class GameEngineModuleTests
    {
        private IContainer _container;

        [SetUp]
        public void Setup()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<GameEngineModule>();
            _container = containerBuilder.Build(ContainerBuildOptions.IgnoreStartableComponents);
        }

        [TestCase(typeof(IGame))]
        [TestCase(typeof(IWorld))]
        public void Load_TypesAreRegistered(Type type)
        {
            Assert.IsTrue(_container.IsRegistered(type));
        }
    }
}
