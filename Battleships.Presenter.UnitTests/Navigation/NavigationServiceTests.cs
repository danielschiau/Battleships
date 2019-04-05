using System;
using Battleships.Presenter.Navigation;
using Battleships.Presenter.Pages.Base;
using Battleships.Presenter.Pages.MainWindow;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace Battleships.Presenter.UnitTests.Navigation
{
    public class NavigationServiceTests
    {
        private readonly AutoMocker _mocker = new AutoMocker();
        private NavigationService _subjectUnderTest;

        [SetUp]
        public void Setup()
        {
            SetupMainWindowProvider();

            _subjectUnderTest = _mocker.CreateInstance<NavigationService>();
        }

        [Test]
        public void NavigateToViewModel_CallsMainWindowProvider()
        {
            _subjectUnderTest.NavigateToViewModel(_mocker.Get<IViewModel>());

            _mocker.Verify<IMainWindowProvider>(x => x.GetMainWindowContext(), Times.Once);
        }

        [Test]
        public void NavigateToViewModel_SetsTheContainerViewModel()
        {
            _subjectUnderTest.NavigateToViewModel(_mocker.Get<IViewModel>());

            _mocker.GetMock<IMainWindowViewModel>().VerifySet(x => x.ContainerViewModel = _mocker.Get<IViewModel>(), Times.Exactly(2));
        }

        [Test]
        public void PopUpMessage_CallsWindowProviderInvokeMethod()
        {
            _subjectUnderTest.PopUpMessage("Title", "Message");

            _mocker.Verify<IMainWindowProvider>(x => x.Invoke(It.IsAny<Action>()), Times.Once);
        }

        private void SetupMainWindowProvider()
        {
            _mocker.GetMock<IMainWindowProvider>()
                .Setup(x => x.GetMainWindowContext())
                .Returns(_mocker.Get<IMainWindowViewModel>());
        }
    }
}
