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
            _subjectUnderTest = new SeaWorld(10);
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

        [Test]
        public void EvaluateHit_WithHitCell_SetsTheCellToHit()
        {
            var cell = new MapCell(1, 2);
            _subjectUnderTest.Map[cell.Row, cell.Column].Character = new SeaShipCharacterBuilder()
                .WithPosition(new List<MapCell> { _subjectUnderTest.Map[cell.Row, cell.Column] })
                .Build();

            _subjectUnderTest.EvaluateHit(cell);

            Assert.AreEqual(MapCellStateType.Hit, _subjectUnderTest.Map[cell.Row, cell.Column].State);
        }

        [Test]
        public void PlaceOnMap_WithCharacter_UpdatesTheCharacterPosition()
        {
            var character = new SeaShipCharacterBuilder().Build();

            _subjectUnderTest.PlaceOnMap(character);

            Assert.AreEqual(character.Size, character.Position.Count);
        }

        [Test]
        public void PlaceOnMap_WithCharacter_UpdatesTheMapCells()
        {
            var character = new SeaShipCharacterBuilder().Build();

            _subjectUnderTest.PlaceOnMap(character);

            Assert.AreEqual(character.Size, _subjectUnderTest.Map.Cast<MapCell>().Count(x => x.Character != null));
        }

        [Test]
        public void PlaceOnMap_WithCharacter_PlacesCharacterCorrectly()
        {
            var character = new SeaShipCharacterBuilder().Build();

            _subjectUnderTest.PlaceOnMap(character);

            Assert.IsTrue(character.Position.Select(x => x.Column).Distinct().FirstOrDefault() != default(int) ||
                          character.Position.Select(x => x.Row).Distinct().FirstOrDefault() != default(int));
        }

        [Test]
        public void PlaceOnMap_WithFullMap_DoesNotAllocateCharacter()
        {
            var allocatedCharacter = new SeaShipCharacterBuilder().Build();
            var characterToAllocate = new SeaShipCharacterBuilder().Build();

            foreach (var mapCell in _subjectUnderTest.Map.Cast<MapCell>())
            {
                mapCell.Character = allocatedCharacter;
            }

            _subjectUnderTest.PlaceOnMap(characterToAllocate);

            Assert.IsNull(characterToAllocate.Position);
        }
    }
}
