using System.Collections.Generic;
using System.Linq;
using Battleships.GameEngine.Characters;
using Battleships.GameEngine.Worlds;
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
            Assert.DoesNotThrow(() => SubjectUnderTest.EvaluateHit(new WorldCell(0, 0)));
        }

        [Test]
        public void EvaluateHit_WithHeadHit_MarksAllCellsAsHit()
        {
            var headHit = new WorldCell(1, 2);
            SubjectUnderTest.Position = new List<WorldCell> { headHit, new WorldCell(2, 2) };

            SubjectUnderTest.EvaluateHit(headHit);

            Assert.IsTrue(SubjectUnderTest.Position.All(x => x.State == WorldCellStateType.Hit));
        }

        [Test]
        public void EvaluateHit_WithHeadHit_MarksAsDestroyed()
        {
            var headHit = new WorldCell(1, 2);
            SubjectUnderTest.Position = new List<WorldCell> { headHit, new WorldCell(2, 2) };

            SubjectUnderTest.EvaluateHit(headHit);

            Assert.IsTrue(SubjectUnderTest.IsDestroyed);
        }

        [Test]
        public void EvaluateHit_WithTailHit_DoesNotMarkAsDestroyed()
        {
            var tailHit = new WorldCell(2, 2);
            SubjectUnderTest.Position = new List<WorldCell> { new WorldCell( 1, 2), tailHit };

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
            var headCell = new WorldCell(1, 2);

            SubjectUnderTest.Position = new List<WorldCell> { headCell, new WorldCell( 2, 2) };

            Assert.AreEqual(headCell, SubjectUnderTest.Head);
        }
    }
}
