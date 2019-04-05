using Battleships.Presenter.Pages.MainWindow;
using Battleships.Presenter.Pages.Settings;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace Battleships.Presenter.UnitTests.Pages.MainWindow
{
    public class MainWindowViewModelTests
    {
        private readonly AutoMocker _mocker = new AutoMocker();
        private MainWindowViewModel _subjectUnderTest;

        [SetUp]
        public void Setup()
        {
            _subjectUnderTest = new MainWindowViewModel(_mocker.Get<ISettingsViewModel>());
        }

        [Test]
        public void Constructor_ContainerViewModel_IsProperlyInitialized()
        {
            Assert.IsInstanceOf(typeof(ISettingsViewModel), _subjectUnderTest.ContainerViewModel);
        }
    }
}
