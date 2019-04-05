using System;
using System.Windows;
using Battleships.Presenter.Pages.MainWindow;

namespace Battleships.Presenter.Navigation
{
    public class MainWindowProvider : IMainWindowProvider
    {
        public IMainWindowViewModel GetMainWindowContext() => Application.Current?.MainWindow?.DataContext as IMainWindowViewModel;

        public void Invoke(Action action)
        {
            Application.Current.Dispatcher.Invoke(action);
        }
    }
}
