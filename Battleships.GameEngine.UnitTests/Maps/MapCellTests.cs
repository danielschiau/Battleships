using Battleships.GameEngine.Worlds;
using NUnit.Framework;

namespace Battleships.GameEngine.UnitTests.Maps
{
    public class MapCellTests
    {
        private MapCell _subjectUnderTest;

        [SetUp]
        public virtual void Setup()
        {
            _subjectUnderTest = new MapCell(1, 2);
        }

        [Test]
        public void Equals_WithMatch_ReturnsTrue()
        {
            var result = _subjectUnderTest.Equals(new MapCell(_subjectUnderTest.Row, _subjectUnderTest.Column));

            Assert.IsTrue(result);
        }

        [Test]
        public void Equals_WithNoMatch_ReturnsFalse()
        {
            var result = _subjectUnderTest.Equals(new MapCell(_subjectUnderTest.Row + 1, _subjectUnderTest.Column + 1));

            Assert.IsFalse(result);
        }
    }
}
