using Battleships.Presenter.Navigation;
using Battleships.Presenter.Pages.Base;
using Battleships.Presenter.Pages.MainWindow;
using Moq;
using NUnit.Framework;

namespace Battleships.Presenter.UnitTests.Navigation
{
    public class NavigationServiceTests
    {
        private NavigationService _subjectUnderTest;
        private Mock<IViewModel> _viewModelMock;
        private Mock<IMainWindowProvider> _mainWindowProviderMock;
        private Mock<IMainWindowViewModel> _mainWindowViewModelMock;

        [SetUp]
        public void Setup()
        {
            _mainWindowViewModelMock = new Mock<IMainWindowViewModel>();

            _mainWindowProviderMock = new Mock<IMainWindowProvider>();
            _mainWindowProviderMock
                .Setup(x => x.GetMainWindowContext())
                .Returns(_mainWindowViewModelMock.Object);

            _viewModelMock = new Mock<IViewModel>();

            _subjectUnderTest = new NavigationService(_mainWindowProviderMock.Object);
        }

        [Test]
        public void NavigateToViewModel_CallsMainWindowProvider()
        {
            _subjectUnderTest.NavigateToViewModel(_viewModelMock.Object);

            _mainWindowProviderMock.Verify(x => x.GetMainWindowContext(), Times.Once);
        }

        [Test]
        public void NavigateToViewModel_SetsTheContainerViewModel()
        {
            _subjectUnderTest.NavigateToViewModel(_viewModelMock.Object);

            _mainWindowViewModelMock.VerifySet(x => x.ContainerViewModel, Times.Once());
        }
    }
}
