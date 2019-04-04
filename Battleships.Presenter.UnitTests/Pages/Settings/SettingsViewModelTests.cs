using Battleships.GameEngine.Games;
using Battleships.GameEngine.Worlds;
using Battleships.Presenter.Navigation;
using Battleships.Presenter.Pages.GamePlay;
using Battleships.Presenter.Pages.MainWindow;
using Battleships.Presenter.Pages.Settings;
using Castle.Core.Internal;
using Moq;
using NUnit.Framework;
using System;

namespace Battleships.Presenter.UnitTests.Pages.Settings
{
    public class SettingsViewModelTests
    {
        private SettingsViewModel _subjectUnderTest;
        private Mock<INavigationService> _navigationServiceMock;
        private Mock<IGamePlayViewModel> _gamePlayViewModelMock;

        [SetUp]
        public void Setup()
        {
            _gamePlayViewModelMock = new Mock<IGamePlayViewModel>();
            _gamePlayViewModelMock
                .Setup(x => x.BattleField.Render(It.IsAny<WorldCell[,]>(), It.IsAny<Action<WorldCell>>()))
                .Verifiable();

            _navigationServiceMock = new Mock<INavigationService>();

            _subjectUnderTest = new SettingsViewModel(_navigationServiceMock.Object, _gamePlayViewModelMock.Object);
        }

        [Test]
        public void Constructor_DefaultSettingsAreInitialized()
        {
            Assert.IsFalse(_subjectUnderTest.Ships.IsNullOrEmpty());
            Assert.IsFalse(_subjectUnderTest.GridSizeOptions.IsNullOrEmpty());
        }

        [Test]
        public void NavigateToGamePlayCommand_CallsGameplayWithProperSettings()
        {
            _subjectUnderTest.NavigateToGamePlayCommand.Execute(null);

            _gamePlayViewModelMock.Verify(x => x.StartBattle(It.IsAny<GameSettings>()), Times.Once);
        }
    }
}
