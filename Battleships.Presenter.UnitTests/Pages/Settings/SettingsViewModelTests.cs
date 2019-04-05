using Battleships.GameEngine.Games;
using Battleships.Presenter.Navigation;
using Battleships.Presenter.Pages.GamePlay;
using Battleships.Presenter.Pages.Settings;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace Battleships.Presenter.UnitTests.Pages.Settings
{
    public class SettingsViewModelTests
    {
        private readonly AutoMocker _mocker = new AutoMocker();
        private SettingsViewModel _subjectUnderTest;

        [SetUp]
        public void Setup()
        {
            _subjectUnderTest = new SettingsViewModel(_mocker.Get<INavigationService>(), _mocker.Get<IGamePlayViewModel>());
        }

        [Test]
        public void Constructor_DefaultSettingsAreInitialized()
        {
            CollectionAssert.IsNotEmpty(_subjectUnderTest.Ships);
            CollectionAssert.IsNotEmpty(_subjectUnderTest.GridSizeOptions);
        }

        [Test]
        public void NavigateToGamePlayCommand_CallsGamePlayWithProperSettings()
        {
            _subjectUnderTest.NavigateToGamePlayCommand.Execute();

            _mocker.Verify<IGamePlayViewModel>(x => x.Start(It.IsAny<GameSettings>()), Times.Once);
        }
    }
}
