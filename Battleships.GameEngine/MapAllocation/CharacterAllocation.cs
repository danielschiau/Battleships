using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.GameEngine.Worlds;

namespace Battleships.GameEngine.MapAllocation
{
    public class CharacterAllocation
    {
        private const int MaxRetries = 10000;
       
        private readonly Random _random = new Random(DateTime.Now.Millisecond);
        private readonly int _characterSize;
        private readonly MapCell[,] _map;

        private bool IsHorizontal => _random.Next(2) == 0;

        public CharacterAllocation(int characterSize, MapCell[,] map)
        {
            _characterSize = characterSize;
            _map = map;
        }

        public IEnumerable<MapCell> Allocate()
        {
            for (int index = 0; index < MaxRetries; index++)
            {
                int startPosition = _random.Next(_map.GetLength(0) - _characterSize);
                IEnumerable<MapCell> freePositions = GetFreePositions(startPosition, IsHorizontal).ToList();

                if (freePositions.Count() == _characterSize)
                {
                    return freePositions;
                }
            }
            
            throw new Exception("Max retries reached");
        }

        private IEnumerable<MapCell> GetFreePositions(int startPosition, bool isHorizontal)
        {
            for (int index = startPosition; index < startPosition + _characterSize; index++)
            {
                if (isHorizontal && IsCellEmpty(startPosition, index))
                {
                    yield return _map[startPosition, index];
                }

                if (!isHorizontal && IsCellEmpty(index, startPosition))
                {
                    yield return _map[index, startPosition];
                }
            }
        }

        private bool IsCellEmpty(int row, int column)
        {
            return _map[row, column].Character == null;
        }
    }
}