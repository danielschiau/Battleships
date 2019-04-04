using Battleships.Presenter.Pages.Base;

namespace Battleships.Presenter.Navigation
{
    public interface INavigationService
    {
        void NavigateToViewModel(IViewModel viewModel);
        void PopUpMessage(string title, string message);
    }
}
