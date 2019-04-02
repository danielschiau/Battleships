using Battleships.Presenter.Pages.Base;

namespace Battleships.Presenter.Navigation
{
    public interface INavigationService
    {
        void NavigateToViewModel(BaseViewModel viewModel);
        void PopUpMessage(string title, string message);
    }
}
