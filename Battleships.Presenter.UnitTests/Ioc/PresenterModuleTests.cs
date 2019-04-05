using System;
using Autofac;
using Autofac.Builder;
using Battleships.Presenter.Ioc;
using Battleships.Presenter.Navigation;
using Battleships.Presenter.Pages.Battlefield;
using Battleships.Presenter.Pages.GamePlay;
using Battleships.Presenter.Pages.MainWindow;
using Battleships.Presenter.Pages.Settings;
using NUnit.Framework;

namespace Battleships.Presenter.UnitTests.Ioc
{
    public class PresenterModuleTests
    {
        private IContainer _container;

        [SetUp]
        public void Setup()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<PresenterModule>();
            _container = containerBuilder.Build(ContainerBuildOptions.IgnoreStartableComponents);
        }

        [TestCase(typeof(INavigationService))]
        [TestCase(typeof(IMainWindowProvider))]
        [TestCase(typeof(IBattlefieldViewModel))]
        [TestCase(typeof(IGamePlayViewModel))]
        [TestCase(typeof(IMainWindowViewModel))]
        [TestCase(typeof(ISettingsViewModel))]
        public void Load_TypesAreRegistered(Type type)
        {
            Assert.IsTrue(_container.IsRegistered(type));
        }
    }
}
