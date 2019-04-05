using Battleships.GameEngine.Characters;
using Battleships.GameEngine.UnitTests.Builders;
using NUnit.Framework;

namespace Battleships.GameEngine.UnitTests.Characters
{
    public class BattleshipCharacterTests : SeaShipCharacterTests
    {
        [SetUp]
        public override void Setup()
        {
            Map = new MapBuilder(10).Build();
            ExpectedName = "BattleshipName";
            SubjectUnderTest = new BattleshipCharacter(ExpectedName);
        }

        [Test]
        public void Constructor_SizeIsSet()
        {
            Assert.AreEqual(SubjectUnderTest.Size, 5);
        }
    }
}
