using Battleships.Presenter.Pages.Base;

namespace Battleships.Presenter.Pages.MainWindow
{
    public interface IMainWindowViewModel : IViewModel
    {
        IViewModel ContainerViewModel { get; set; }
    }
}
