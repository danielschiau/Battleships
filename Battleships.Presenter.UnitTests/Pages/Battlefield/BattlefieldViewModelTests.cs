using System;
using Battleships.GameEngine.Worlds;
using Battleships.Presenter.Pages.Battlefield;
using Gu.Wpf.DataGrid2D;
using Moq;
using NUnit.Framework;

namespace Battleships.Presenter.UnitTests.Pages.Battlefield
{
    public class BattlefieldViewModelTests
    {
        private Mock<Action<MapCell>> _onCellClickMock;
        private BattlefieldViewModel _subjectUnderTest;

        [SetUp]
        public void Setup()
        {
            _onCellClickMock = new Mock<Action<MapCell>>();
            _onCellClickMock
                .Setup(x => x(It.IsAny<MapCell>()))
                .Verifiable();

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

            _subjectUnderTest.ToggleDebugModeCommand.Execute(null);

            Assert.IsTrue(_subjectUnderTest.IsDebugMode != initialState);
        }

        [Test]
        public void CellSelectedCommand_WithGivenSelectedCellIndex_ExecutesCallback()
        {
            var map = new MapCell[,]
            {
                {
                    new MapCell(0, 0),
                    new MapCell(0, 1),
                },
                {
                    new MapCell(1, 0),
                    new MapCell(1, 1),
                }
            };
            _subjectUnderTest.SelectedCellIndex = new RowColumnIndex(0, 1);
            _subjectUnderTest.Render(map, _onCellClickMock.Object); 

            _subjectUnderTest.CellSelectedCommand.Execute(null);

            _onCellClickMock.Verify(x => x(map[_subjectUnderTest.SelectedCellIndex.Row, _subjectUnderTest.SelectedCellIndex.Column]), Times.Once);
        }
    }
}
