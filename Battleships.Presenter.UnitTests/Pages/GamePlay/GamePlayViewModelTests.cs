using System;
using Battleships.GameEngine.Games;
using Battleships.GameEngine.Worlds;
using Battleships.Presenter.Navigation;
using Battleships.Presenter.Pages.Battlefield;
using Battleships.Presenter.Pages.GamePlay;
using Moq;
using NUnit.Framework;

namespace Battleships.Presenter.UnitTests.Pages.GamePlay
{
    public class GamePlayViewModelTests
    {
        private GamePlayViewModel _subjectUnderTest;
        private Mock<IGamePlay> _gamePlayMock;
        private Mock<INavigationService> _navigationServiceMock;
        private Mock<IBattlefieldViewModel> _battlefieldViewModelMock;

        [SetUp]
        public void Setup()
        {
           _gamePlayMock = new Mock<IGamePlay>();

            _battlefieldViewModelMock = new Mock<IBattlefieldViewModel>();
            _battlefieldViewModelMock
                .Setup(x => x.Render(It.IsAny<MapCell[,]>(), It.IsAny<Action<MapCell>>()))
                .Verifiable();

            _navigationServiceMock = new Mock<INavigationService>();
            _navigationServiceMock
                .Setup(x => x.PopUpMessage(It.IsAny<string>(), It.IsAny<string>()))
                .Verifiable();

            _subjectUnderTest = new GamePlayViewModel(_navigationServiceMock.Object, _battlefieldViewModelMock.Object);
        }

        [Test]
        public void Constructor_BattlefieldViewModel_IsInitialized()
        {
            Assert.IsInstanceOf(typeof(IBattlefieldViewModel), _subjectUnderTest.BattleField);
        }

        [Test]
        public void StartBattle_CreatesANewGame()
        {
            _subjectUnderTest.Game = null;

            _subjectUnderTest.StartBattle(new GameSettings());

            Assert.IsNotNull(_subjectUnderTest.Game);
        }

        [Test]
        public void OnCellSelected_WithGivenCell_CallsGameEvaluateHit()
        {
            _subjectUnderTest.Game = _gamePlayMock.Object;

            _subjectUnderTest.OnCellSelected(new MapCell(0, 0));

            _gamePlayMock.Verify(x => x.EvaluateHit(It.IsAny<MapCell>()), Times.Once);
        }

        [Test]
        public void OnCellSelected_WithGameOver_CallsPopupNavigationService()
        {
            _gamePlayMock
                .SetupGet(ex => ex.IsGameOver)
                .Returns(() => true);

            _subjectUnderTest.Game = _gamePlayMock.Object;

            _subjectUnderTest.OnCellSelected(new MapCell(0,0));

            _navigationServiceMock.Verify(x => x.PopUpMessage(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
