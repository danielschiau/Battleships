using System.Collections.Generic;
using Battleships.GameEngine.Characters;
using Battleships.GameEngine.Worlds;

namespace Battleships.GameEngine.UnitTests.Builders
{
    public class SeaShipCharacterBuilder
    {
        private readonly SeaShipCharacter _seaShipCharacter;

        public SeaShipCharacterBuilder()
        {
            _seaShipCharacter = new SeaShipCharacter("SeaShipCharacter", 4);
        }

        public SeaShipCharacterBuilder WithPosition(List<MapCell> position)
        {
            _seaShipCharacter.Position = position;
            return this;
        }

        public SeaShipCharacter Build()
        {
            return _seaShipCharacter;
        }
    }
}
