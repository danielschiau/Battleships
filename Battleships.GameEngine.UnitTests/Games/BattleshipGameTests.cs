using System.Collections.Generic;
using System.Linq;
using Battleships.GameEngine.Characters;
using Battleships.GameEngine.Games;
using Battleships.GameEngine.Worlds;
using NUnit.Framework;

namespace Battleships.GameEngine.UnitTests.Games
{
    public class BattleshipGameTests
    {
        private BattleshipGame _subjectUnderTest;

        [SetUp]
        public virtual void Setup()
        {
            _subjectUnderTest = new BattleshipGame(new GameSettings
            {
                MapSize = 10,
                Characters = new List<ICharacter> { new BattleshipCharacter("Battleship") }
            });
        }

        [Test]
        public void Constructor_WorldIsSet()
        {
            Assert.IsNotNull(_subjectUnderTest.World);
        }

        [Test]
        public void Constructor_CharactersArePlacedOnMap()
        {
            Assert.IsTrue(_subjectUnderTest.Characters.All(x => x.Position != null));
        }

        [Test]
        public void EvaluateHit_WithMissCell_SetsTheCellAsTested()
        {
            var cell = new WorldCell(1,2);
            _subjectUnderTest.World.World[cell.Row, cell.Column].Character = null;

            _subjectUnderTest.EvaluateHit(cell);

            Assert.AreEqual(WorldCellStateType.Tested, _subjectUnderTest.World.World[cell.Row, cell.Column].State);
        }

        [Test]
        public void EvaluateHit_AllCharactersDestroyed_TheGameIsOver()
        {
            var cell = new WorldCell(1, 2);
            _subjectUnderTest.Characters.ForEach(x => x.Position.ForEach(p => p.State = WorldCellStateType.Hit));

            _subjectUnderTest.EvaluateHit(cell);

            Assert.IsTrue(_subjectUnderTest.IsGameOver);
        }
    }
}
