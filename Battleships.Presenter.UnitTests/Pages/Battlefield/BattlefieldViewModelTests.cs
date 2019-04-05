using System;
using Battleships.GameEngine.Worlds;
using Battleships.Presenter.Pages.Battlefield;
using Gu.Wpf.DataGrid2D;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace Battleships.Presenter.UnitTests.Pages.Battlefield
{
    public class BattlefieldViewModelTests
    {
        private readonly AutoMocker _mocker = new AutoMocker();
        private BattlefieldViewModel _subjectUnderTest;

        [SetUp]
        public void Setup()
        {
            SetupOnCellClick();

            _subjectUnderTest = new BattlefieldViewModel();
        }

        [Test]
        public void Constructor_MapIsInitializedInDebugMode()
        {
            Assert.IsTrue(_subjectUnderTest.IsDebugMode);
        }

        [Test]
        public void Constructor_GridHeadersAreInitialized()
        {
            Assert.IsNotEmpty(_subjectUnderTest.RowHeaders);
            Assert.IsNotEmpty(_subjectUnderTest.ColumnHeaders);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ToggleDebugModeCommand_WithGivenDebuggingState_TogglesTheDebugState(bool initialState)
        {
            _subjectUnderTest.IsDebugMode = initialState;

            _subjectUnderTest.ToggleDebugModeCommand.Execute();

            Assert.IsTrue(_subjectUnderTest.IsDebugMode != initialState);
        }

        [Test]
        public void CellSelectedCommand_WithGivenSelectedCellIndex_ExecutesCallback()
        {
            var map = CreateMap(2);
            _subjectUnderTest.SelectedCellIndex = new RowColumnIndex(0, 1);
            _subjectUnderTest.Render(map, _mocker.Get<Action<MapCell>>()); 

            _subjectUnderTest.CellSelectedCommand.Execute();

            _mocker.Verify<Action<MapCell>>(x => x(map[_subjectUnderTest.SelectedCellIndex.Row, _subjectUnderTest.SelectedCellIndex.Column]), Times.Once);
        }

        private MapCell[,] CreateMap(int size)
        {
            var result = new MapCell[size, size];

            for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    result[row, column] = new MapCell(row, column);
                }
            }

            return result;
        }

        private void SetupOnCellClick()
        {
            _mocker.GetMock<Action<MapCell>>()
                .Setup(x => x(It.IsAny<MapCell>()))
                .Verifiable();
        }
    }
}
