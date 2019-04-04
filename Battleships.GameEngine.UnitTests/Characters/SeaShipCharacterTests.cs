using System.Collections.Generic;
using System.Linq;
using Battleships.GameEngine.Characters;
using Battleships.GameEngine.Maps;
using NUnit.Framework;

namespace Battleships.GameEngine.UnitTests.Characters
{
    public class SeaShipCharacterTests
    {
        protected ICharacter SubjectUnderTest;
        protected string ExpectedName;

        [SetUp]
        public virtual void Setup()
        {
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
        }

        [Test]
        public void Head_WithNullPosition_IsNull()
        {
            Assert.IsNull(SubjectUnderTest.Head);
        }

        [Test]
        public void Head_WithSomePosition_IsFirstCell()
        {
            var headCell = new MapCell(1, 2);

            SubjectUnderTest.Position = new List<MapCell> { headCell, new MapCell( 2, 2) };

            Assert.AreEqual(headCell, SubjectUnderTest.Head);
        }
    }
}
