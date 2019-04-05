using System.Collections.Generic;
using System.Linq;
using Battleships.GameEngine.Characters;
using Battleships.GameEngine.UnitTests.Builders;
using Battleships.GameEngine.Worlds;
using NUnit.Framework;

namespace Battleships.GameEngine.UnitTests.Characters
{
    public class SeaShipCharacterTests
    {
        protected MapCell[,] Map;
        protected ICharacter SubjectUnderTest;
        protected string ExpectedName;

        [SetUp]
        public virtual void Setup()
        {
            Map = new MapBuilder(10).Build();
            ExpectedName = "ShipName";
            SubjectUnderTest = new SeaShipCharacter(ExpectedName, 2);
        }

        [Test]
        public void Constructor_NameIsSet()
        {
            Assert.AreEqual(SubjectUnderTest.Name, ExpectedName);
        }

        [Test]
        public void EvaluateHit_WithNoPositionOnMap_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() => SubjectUnderTest.EvaluateHit(new MapCell(0, 0)));
        }

        [Test]
        public void EvaluateHit_WithHeadHit_MarksAllCellsAsHit()
        {
            var headHit = new MapCell(1, 2);
            SubjectUnderTest.Position = new List<MapCell> { headHit, new MapCell(2, 2) };

            SubjectUnderTest.EvaluateHit(headHit);

            Assert.IsTrue(SubjectUnderTest.Position.All(x => x.State == MapCellStateType.Hit));
        }

        [Test]
        public void EvaluateHit_WithHeadHit_MarksAsDestroyed()
        {
            var headHit = new MapCell(1, 2);
            SubjectUnderTest.Position = new List<MapCell> { headHit, new MapCell(2, 2) };

            SubjectUnderTest.EvaluateHit(headHit);

            Assert.IsTrue(SubjectUnderTest.IsDestroyed);
        }

        [Test]
        public void EvaluateHit_WithTailHit_DoesNotMarkAsDestroyed()
        {
            var tailHit = new MapCell(2, 2);
            SubjectUnderTest.Position = new List<MapCell> { new MapCell( 1, 2), tailHit };

            SubjectUnderTest.EvaluateHit(tailHit);

            Assert.IsFalse(SubjectUnderTest.IsDestroyed);
            Assert.IsTrue(SubjectUnderTest.Position.First(x => x.Row == tailHit.Row && x.Column == tailHit.Column ).State == MapCellStateType.Hit);
        }

        [Test]
        public void Head_WithNullPosition_IsNull()
        {
            Assert.IsNull(SubjectUnderTest.Head);
        }

        [Test]
        public void Head_WithSomePosition_IsFirstCell()
        {
            SubjectUnderTest.Position = new List<MapCell> { new MapCell(1, 2), new MapCell( 2, 2) };

            Assert.AreEqual(SubjectUnderTest.Position.First(), SubjectUnderTest.Head);
        }

        [Test]
        public void PlaceOnMap_WithCharacter_UpdatesTheCharacterPosition()
        {
            SubjectUnderTest.PlaceOnMap(Map);

            Assert.AreEqual(SubjectUnderTest.Size, SubjectUnderTest.Position.Count);
        }

        [Test]
        public void PlaceOnMap_WithCharacter_PlacesCharacterCorrectly()
        {
            SubjectUnderTest.PlaceOnMap(Map);

            Assert.IsTrue(IsVerticallyPlacedCorrectly() || IsHorizontallyPlacedCorrectly());
        }

        [Test]
        public void PlaceOnMap_WithFullMap_DoesNotAllocateCharacter()
        {
            var allocatedCharacter = new SeaShipCharacterBuilder().Build();

            foreach (var mapCell in Map.Cast<MapCell>())
            {
                mapCell.Character = allocatedCharacter;
            }

            SubjectUnderTest.PlaceOnMap(Map);

            Assert.IsNull(SubjectUnderTest.Position);
        }

        private bool IsVerticallyPlacedCorrectly()
        {
            return SubjectUnderTest.Position.Select(x => x.Column).Distinct().Count() == 1 &&
                   SubjectUnderTest.Position.Select(x => x.Row).Distinct().Count() == SubjectUnderTest.Size;
        }

        private bool IsHorizontallyPlacedCorrectly()
        {
            return SubjectUnderTest.Position.Select(x => x.Row).Distinct().Count() == 1 &&
                   SubjectUnderTest.Position.Select(x => x.Column).Distinct().Count() == SubjectUnderTest.Size;
        }
    }
}
