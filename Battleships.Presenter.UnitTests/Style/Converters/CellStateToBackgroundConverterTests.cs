using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Media;
using Battleships.GameEngine.Characters;
using Battleships.GameEngine.Worlds;
using Battleships.Presenter.Style.Converters;
using NUnit.Framework;

namespace Battleships.Presenter.UnitTests.Style.Converters
{
    public class CellStateToBackgroundConverterTests
    {
        private MapCell _mapCell;
        private CellStateToBackgroundConverter _subjectUnderTest;

        [SetUp]
        public void Setup()
        {
            _mapCell = new MapCell(0, 0)
            {
                Character = new BattleshipCharacter("BattleshipCharacter")
                {
                    Position = new List<MapCell> { new MapCell(0, 0) }
                }
            };

            _subjectUnderTest = new CellStateToBackgroundConverter();
        }

        [Test]
        public void Convert_WithHeadHit_ReturnsDarkRed()
        {
            _mapCell.State = MapCellState.Hit;

            var result = _subjectUnderTest.Convert(_mapCell, null, null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Colors.DarkRed, GetBrushColor(result));
        }

        [Test]
        public void Convert_WithOutOfRangeState_ReturnsWhiteSmoke()
        {
            _mapCell.State = (MapCellState)5;
            _mapCell.Character.Position = new List<MapCell>(new List<MapCell> { new MapCell(1,2) });

            var result = _subjectUnderTest.Convert(_mapCell, null, null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Colors.WhiteSmoke, GetBrushColor(result));
        }

        [Test]
        public void Convert_WithTailHit_ReturnsRed()
        {
            _mapCell.State = MapCellState.Hit;
            _mapCell.Character.Position = new List<MapCell>(new List<MapCell> { new MapCell(1, 2) });

            var result = _subjectUnderTest.Convert(_mapCell, null, null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Colors.Red, GetBrushColor(result));
        }

        [Test]
        public void Convert_WithTestHit_ReturnsGray()
        {
            _mapCell.State = MapCellState.Touched;

            var result = _subjectUnderTest.Convert(_mapCell, null, null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Colors.Gray, GetBrushColor(result));
        }

        [Test]
        public void Convert_WithNoHit_ReturnWhiteSmoke()
        {
            _mapCell.State = MapCellState.Untouched;

            var result = _subjectUnderTest.Convert(_mapCell, null, null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Colors.WhiteSmoke, GetBrushColor(result));
        }

        [Test]
        public void Convert_WithNullCell_ReturnWhiteSmoke()
        {
            var result = _subjectUnderTest.Convert(null, null, null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Colors.WhiteSmoke, GetBrushColor(result));
        }

        [Test]
        public void ConvertBack_ThrowsNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() => _subjectUnderTest.ConvertBack(_mapCell, null, null, CultureInfo.InvariantCulture));
        }

        private Color GetBrushColor(object brush)
        {
            return (brush as SolidColorBrush).Color;
        }
    }
}
