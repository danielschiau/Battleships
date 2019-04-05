using Battleships.GameEngine.Characters;
using Battleships.GameEngine.UnitTests.Builders;
using NUnit.Framework;

namespace Battleships.GameEngine.UnitTests.Characters
{
    public class DestroyerCharacterTests : SeaShipCharacterTests
    {
        [SetUp]
        public override void Setup()
        {
            Map = new MapBuilder(10).Build();
            ExpectedName = "DestroyerName";
            SubjectUnderTest = new DestroyerCharacter(ExpectedName);
        }

        [Test]
        public void Constructor_SizeIsSet()
        {
            Assert.AreEqual(SubjectUnderTest.Size, 4);
        }
    }
}
