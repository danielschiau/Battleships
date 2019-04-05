using System;
using Battleships.GameEngine.Games;
using Battleships.GameEngine.Worlds;
using Battleships.Presenter.Navigation;
using Battleships.Presenter.Pages.Battlefield;
using Battleships.Presenter.Pages.GamePlay;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace Battleships.Presenter.UnitTests.Pages.GamePlay
{
    public class GamePlayViewModelTests
    {
        private readonly AutoMocker _mocker = new AutoMocker();
        private GamePlayViewModel _subjectUnderTest;

        [SetUp]
        public void Setup()
        {
           SetupBattlefieldViewModel();
           SetupNavigationService();

            _subjectUnderTest = new GamePlayViewModel(_mocker.Get<INavigationService>(), _mocker.Get<IGame>(), _mocker.Get<IBattlefieldViewModel>());
        }

        [Test]
        public void Constructor_BattlefieldViewModel_IsInitialized()
        {
            Assert.IsInstanceOf(typeof(IBattlefieldViewModel), _subjectUnderTest.BattleField);
        }

        [Test]
        public void OnCellSelected_WithGivenCell_CallsGameEvaluateHit()
        {
            var mapCell = new MapCell(0, 0);
            _subjectUnderTest.Game = _mocker.Get<IGame>();

            _subjectUnderTest.OnCellSelected(mapCell);

            _mocker.Verify<IGame>(x => x.EvaluateHit(mapCell), Times.Once);
        }

        [Test]
        public void OnCellSelected_WithGameOver_CallsPopupNavigationService()
        {
            _subjectUnderTest.Game = _mocker.Get<IGame>();
            _mocker.GetMock<IGame>().SetupGet(ex => ex.IsOver).Returns(() => true);

            _subjectUnderTest.OnCellSelected(new MapCell(0,0));

            _mocker.Verify<INavigationService>(x => x.PopUpMessage(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        private void SetupBattlefieldViewModel()
        {
            _mocker.GetMock<IBattlefieldViewModel>()
                .Setup(x => x.Render(It.IsAny<MapCell[,]>(), It.IsAny<Action<MapCell>>()))
                .Verifiable();
        }

        private void SetupNavigationService()
        {
            _mocker.GetMock<INavigationService>()
                .Setup(x => x.PopUpMessage(It.IsAny<string>(), It.IsAny<string>()))
                .Verifiable();
        }
    }
}
