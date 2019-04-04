using System.Linq;
using Battleships.GameEngine.Characters;
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
            Assert.AreEqual(_mapSize, _subjectUnderTest.World.GetLongLength(0));
            Assert.AreEqual(_mapSize, _subjectUnderTest.World.GetLongLength(1));
            Assert.IsFalse(_subjectUnderTest.World.Cast<WorldCell>().Contains(null));
        }

        [Test]
        public void EvaluateHit_WithUntouchedCell_SetsTheCellToTested()
        {
            var cell = new WorldCell(1,2);
            _subjectUnderTest.World[cell.Row, cell.Column].State = WorldCellStateType.NotTouched;

            _subjectUnderTest.EvaluateHit(cell);

            Assert.AreEqual(WorldCellStateType.Tested, _subjectUnderTest.World[cell.Row, cell.Column].State);
        }

        [Test]
        public void EvaluateHit_WithHitCell_DoesNotModifyTheStatus()
        {
            var cell = new WorldCell(1, 2);
            _subjectUnderTest.World[cell.Row, cell.Column].State = WorldCellStateType.Hit;

            _subjectUnderTest.EvaluateHit(cell);

            Assert.AreEqual(WorldCellStateType.Hit, _subjectUnderTest.World[cell.Row, cell.Column].State);
        }

        [Test]
        public void PlaceOnMap_WithCharacter_UpdatesTheCharacterPosition()
        {
            var character = new DestroyerCharacter("DestroyerCharacter");

            _subjectUnderTest.PlaceOnMap(character);

            Assert.AreEqual(character.Size, character.Position.Count);
        }

        [Test]
        public void PlaceOnMap_WithCharacter_UpdatesTheMapCells()
        {
            var character = new DestroyerCharacter("DestroyerCharacter");

            _subjectUnderTest.PlaceOnMap(character);

            Assert.AreEqual(character.Size, _subjectUnderTest.World.Cast<WorldCell>().Count(x => x.Character != null));
        }

        [Test]
        public void PlaceOnMap_WithCharacter_PlacesCharacterCorrectly()
        {
            var character = new DestroyerCharacter("DestroyerCharacter");

            _subjectUnderTest.PlaceOnMap(character);

            Assert.IsTrue(character.Position.Select(x => x.Column).Distinct().FirstOrDefault() != default(int) ||
                          character.Position.Select(x => x.Row).Distinct().FirstOrDefault() != default(int));
        }

        [Test]
        public void PlaceOnMap_WithFullMap_DoesNotAllocateCharacter()
        {
            var allocatedCharacter = new DestroyerCharacter("DestroyerCharacter");
            var characterToAllocate = new BattleshipCharacter("BattleshipCharacter");
 
            foreach (var mapCell in _subjectUnderTest.World.Cast<WorldCell>())
            {
                mapCell.Character = allocatedCharacter;
            }

            _subjectUnderTest.PlaceOnMap(characterToAllocate);

            Assert.IsNull(characterToAllocate.Position);
        }
    }
}
