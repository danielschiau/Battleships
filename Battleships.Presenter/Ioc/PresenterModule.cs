using Autofac;
using Battleships.Presenter.Navigation;
using Battleships.Presenter.Pages.Battlefield;
using Battleships.Presenter.Pages.GameOver;
using Battleships.Presenter.Pages.GamePlay;
using Battleships.Presenter.Pages.History;
using Battleships.Presenter.Pages.MainWindow;
using Battleships.Presenter.Pages.Settings;

namespace Battleships.Presenter.Ioc
{
    public class PresenterModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();

            builder.RegisterType<BattlefieldViewModel>().AsSelf();
            builder.RegisterType<GamePlayViewModel>().AsSelf();
            builder.RegisterType<HistoryViewModel>().AsSelf();
            builder.RegisterType<MainWindowViewModel>().AsSelf();
            builder.RegisterType<SettingsViewModel>().AsSelf();
            builder.RegisterType<GameOverViewModel>().AsSelf();
        }
    }
}
