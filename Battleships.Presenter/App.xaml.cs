using System.Windows;
using Autofac;
using Battleships.Presenter.Navigation;

namespace Battleships.Presenter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly INavigationService _navigationService;

        public App()
        {
            Dispatcher.UnhandledException += OnDispatcherUnhandledException;

            _navigationService = Ioc.Ioc.Instance.Resolve<INavigationService>();
        }

        void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            _navigationService.PopUpMessage("Error", e.Exception.Message);
            e.Handled = true;
        }
    }
}
