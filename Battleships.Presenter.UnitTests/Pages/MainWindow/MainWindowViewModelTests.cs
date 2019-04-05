using Battleships.Presenter.Pages.MainWindow;
using Battleships.Presenter.Pages.Settings;
using Moq;
using NUnit.Framework;

namespace Battleships.Presenter.UnitTests.Pages.MainWindow
{
    public class MainWindowViewModelTests
    {
        private MainWindowViewModel _subjectUnderTest;

        [SetUp]
        public void Setup()
        {
            var settingsViewModelMock = new Mock<SettingsViewModel>(null, null);
            _subjectUnderTest = new MainWindowViewModel(settingsViewModelMock.Object);
        }

        [Test]
        public void Constructor_ContainerViewModel_IsProperlyInitialized()
        {
            Assert.IsInstanceOf(typeof(SettingsViewModel), _subjectUnderTest.ContainerViewModel);
        }
    }
}
