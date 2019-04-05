using System.Collections.Generic;
using System.Linq;
using Battleships.GameEngine.Characters;
using Battleships.GameEngine.Games;
using Battleships.GameEngine.UnitTests.Builders;
using Battleships.GameEngine.Worlds;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace Battleships.GameEngine.UnitTests.Games
{
    public class BattleshipGameTests
    {
        private readonly AutoMocker _mocker = new AutoMocker();
        private BattleshipGame _subjectUnderTest;
        private GameSettings _gameSettings;

        [SetUp]
        public virtual void Setup()
        {
            _gameSettings = new GameSettings
            {
                MapSize = 10,
                Characters = new List<ICharacter>
                {
                    new SeaShipCharacterBuilder()
                        .WithPosition(new List<MapCell> {new MapCell(1, 1), new MapCell(1, 2)})
                        .Build()
                }
            };

            SetupWorld();

            _subjectUnderTest = new BattleshipGame(_mocker.Get<IWorld>());
            _subjectUnderTest.Start(_gameSettings);
        }
        
        [Test]
        public void Start_WorldIsSet()
        {
            Assert.IsNotNull(_subjectUnderTest.World);
        }

        [Test]
        public void Start_CharactersArePlacedOnMap()
        {
            Assert.IsTrue(_subjectUnderTest.Characters.All(x => x.Position != null));
        }

        [Test]
        public void EvaluateHit_MapEvaluateHitIsCalled()
        {
            var mapCell = new MapCell(1, 2);

            _subjectUnderTest.EvaluateHit(mapCell);

            _mocker.Verify<IWorld>(x => x.EvaluateHit(mapCell), Times.Once);
        }

        [Test]
        public void EvaluateHit_AllCharactersDestroyed_TheGameIsOver()
        {
            _subjectUnderTest.Start(_gameSettings);
            var cell = new MapCell(1, 2);
            _subjectUnderTest.Characters.ForEach(x => x.Position.ForEach(p => p.State = MapCellStateType.Hit));

            _subjectUnderTest.EvaluateHit(cell);

            Assert.IsTrue(_subjectUnderTest.IsOver);
        }

        private void SetupWorld()
        {
            _mocker.GetMock<IWorld>()
                .SetupGet(x => x.Map)
                .Returns(() =>
                {
                    var mapSize = 10;
                    var map = new MapCell[mapSize, mapSize];

                    for (var row = 0; row < mapSize; row++)
                    {
                        for (var column = 0; column < mapSize; column++)
                        {
                            map[row, column] = new MapCell(row, column);
                        }
                    }

                    return map;
                });
        }
    }
}
