using System.Collections.Generic;
using System.Linq;
using Battleships.GameEngine.UnitTests.Builders;
using Battleships.GameEngine.Worlds;
using NUnit.Framework;

namespace Battleships.GameEngine.UnitTests.Maps
{
    public class SeaWorldTests
    {
        private int _mapSize;
        private SeaWorld _subjectUnderTest;

        [SetUp]
        public virtual void Setup()
        {
            _mapSize = 10;
            _subjectUnderTest = new SeaWorld();
            _subjectUnderTest.CreateMap(_mapSize);
        }

        [Test]
        public void Create_WithGivenSize_ReturnsInitializedMap()
        {
            Assert.AreEqual(_mapSize, _subjectUnderTest.Map.GetLongLength(0));
            Assert.AreEqual(_mapSize, _subjectUnderTest.Map.GetLongLength(1));
            Assert.IsFalse(_subjectUnderTest.Map.Cast<MapCell>().Contains(null));
        }

        [Test]
        public void EvaluateHit_WithUntouchedCell_SetsTheCellToTested()
        {
            var cell = new MapCell(1, 2);
            _subjectUnderTest.Map[cell.Row, cell.Column].State = MapCellStateType.NotTouched;

            _subjectUnderTest.EvaluateHit(cell);

            Assert.AreEqual(MapCellStateType.Tested, _subjectUnderTest.Map[cell.Row, cell.Column].State);
        }
    }
}
