using Battleships.Presenter.Pages.MainWindow;

namespace Battleships.Presenter.Navigation
{
    public interface IMainWindowProvider
    {
        IMainWindowViewModel GetMainWindowContext();
    }
}