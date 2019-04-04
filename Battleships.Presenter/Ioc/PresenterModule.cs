using Autofac;
using Battleships.Presenter.Navigation;
using Battleships.Presenter.Pages.Battlefield;
using Battleships.Presenter.Pages.GamePlay;
using Battleships.Presenter.Pages.MainWindow;
using Battleships.Presenter.Pages.Settings;

namespace Battleships.Presenter.Ioc
{
    public class PresenterModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();

            builder.RegisterType<BattlefieldViewModel>().As<IBattlefieldViewModel>();
            builder.RegisterType<GamePlayViewModel>().As<IGamePlayViewModel>().AsSelf();
            builder.RegisterType<MainWindowViewModel>().As<IMainWindowViewModel>().AsSelf();
            builder.RegisterType<SettingsViewModel>().As<ISettingsViewModel>().AsSelf();
        }
    }
}
