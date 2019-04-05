using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.GameEngine.MapAllocation;
using Battleships.GameEngine.UnitTests.Builders;
using Battleships.GameEngine.Worlds;
using NUnit.Framework;

namespace Battleships.GameEngine.UnitTests.MapAllocation
{
    public class CharacterAllocationTests
    {
        private MapCell[,] _map;
        private IEnumerable<MapCell> _subjectUnderTest;       

        [SetUp]
        public virtual void Setup()
        {
            _map = new MapBuilder(10).Build();
            _subjectUnderTest = new CharacterAllocation(5, _map).Allocate();
        }

        [Test]
        public void PlaceOnMap_WithCharacter_UpdatesTheCharacterPosition()
        {
            Assert.AreEqual(5, _subjectUnderTest.Count());
        }

        [Test]
        public void PlaceOnMap_WithCharacter_PlacesCharacterCorrectly()
        {
            Assert.IsTrue(IsVerticallyPlacedCorrectly() || IsHorizontallyPlacedCorrectly());
        }

        [Test]
        public void PlaceOnMap_WithFullMap_DoesNotAllocateCharacter()
        {
            var allocatedCharacter = new SeaShipCharacterBuilder().Build();

            foreach (var mapCell in _map.Cast<MapCell>())
            {
                mapCell.Character = allocatedCharacter;
            }

            void Act() => new CharacterAllocation(allocatedCharacter.Size, _map).Allocate();

            Assert.Throws<Exception>(Act);
        }
        
        private bool IsVerticallyPlacedCorrectly()
        {
            return _subjectUnderTest.Select(x => x.Column).Distinct().Count() == 1 &&
                   _subjectUnderTest.Select(x => x.Row).Distinct().Count() == _subjectUnderTest.Count();
        }

        private bool IsHorizontallyPlacedCorrectly()
        {
            return _subjectUnderTest.Select(x => x.Row).Distinct().Count() == 1 &&
                   _subjectUnderTest.Select(x => x.Column).Distinct().Count() == _subjectUnderTest.Count();
        }
    }
}