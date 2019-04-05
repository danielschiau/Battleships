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
    public class DebugModeMapConverterTests
    {
        private MapCell _mapCell;
        private DebugModeMapConverter _subjectUnderTest;

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

            _subjectUnderTest = new DebugModeMapConverter();
        }

        [Test]
        public void ConvertBack_ThrowsNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() => _subjectUnderTest.ConvertBack(_mapCell, null, null, CultureInfo.InvariantCulture));
        }

        [Test]
        public void Convert_WithNoHit_ReturnWhiteSmoke()
        {
            _mapCell.Character = null;

            var result = _subjectUnderTest.Convert(_mapCell, null, null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Colors.WhiteSmoke, GetBrushColor(result));
        }

        [Test]
        public void Convert_WithHeadHit_ReturnsDarkBlue()
        {
            var result = _subjectUnderTest.Convert(_mapCell, null, null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Colors.DarkBlue, GetBrushColor(result));
        }

        [Test]
        public void Convert_WithTailHit_ReturnsBlue()
        {
            _mapCell.Character.Position = new List<MapCell>(new List<MapCell> { new MapCell(1, 2) });

            var result = _subjectUnderTest.Convert(_mapCell, null, null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Colors.Blue, GetBrushColor(result));
        }

        [Test]
        public void Convert_WithNullCell_ReturnWhiteSmoke()
        {
            var result = _subjectUnderTest.Convert(null, null, null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Colors.WhiteSmoke, GetBrushColor(result));
        }

        private Color GetBrushColor(object brush)
        {
            return (brush as SolidColorBrush).Color;
        }
    }
}
