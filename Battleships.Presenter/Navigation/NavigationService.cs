﻿using System.Windows;
using Battleships.Presenter.Pages.Base;
using Battleships.Presenter.Pages.MainWindow;
using MahApps.Metro.Controls.Dialogs;

namespace Battleships.Presenter.Navigation
{
    public class NavigationService : INavigationService
    {
        public void NavigateToViewModel(BaseViewModel viewModel)
        {
            GetWindowInstance().ContainerViewModel = viewModel;
        }

        public void PopUpMessage(string title, string message)
        {
            Application.Current.Dispatcher.Invoke(() => DialogCoordinator.Instance.ShowMessageAsync(GetWindowInstance(), title, message));
        }

        private static MainWindowViewModel GetWindowInstance()
        {
            return Application.Current?.MainWindow?.DataContext as MainWindowViewModel;
        }
    }
}
