using Battleships.GameEngine.Characters;
using NUnit.Framework;

namespace Battleships.GameEngine.UnitTests.Characters
{
    public class DestroyerCharacterTests : SeaShipCharacterTests
    {
        [SetUp]
        public override void Setup()
        {
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
