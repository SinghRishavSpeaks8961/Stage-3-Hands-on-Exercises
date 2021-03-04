using System;
using Moq;
using NUnit.Framework;
using PlayersManagerLib;

namespace PlayerManagerTests
{
    [TestFixture]
    public class UnitTest1
    {
        private Mock<IPlayerMapper> _registerPlayer;

        [OneTimeSetUp]
        public void SetUp()
        {
            _registerPlayer = new Mock<IPlayerMapper>();
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void RegisterNewPlayer_WhenEmptyOrNullStringsArePassed_ShouldThrowArgumetException(string input)
        {
            Assert.Throws<ArgumentException>(() => Player.RegisterNewPlayer(input, _registerPlayer.Object));
        }

        [Test]
        [TestCase("Rishav")]
        public void RegisterNewPlayer_WhenPlayerNameExistInDb_ShouldThrowArgumetException(string input)
        {
            _registerPlayer.Setup(rp => rp.IsPlayerNameExistsInDb(input)).Returns(true);
            Assert.Throws<ArgumentException>(() => Player.RegisterNewPlayer(input, _registerPlayer.Object));
        }

        [Test]
        [TestCase("Roshan")]
        public void RegisterNewPlayer_WhenCalled_ShouldAddNewPlayer(string input)
        {
            _registerPlayer.Setup(rp => rp.IsPlayerNameExistsInDb(input)).Returns(false);
            _registerPlayer.Setup(rp => rp.AddNewPlayerIntoDb(input));

            var result = Player.RegisterNewPlayer(input, _registerPlayer.Object);

            Assert.That(result, Is.TypeOf<Player>());
            Assert.That(result.Country, Is.EqualTo("India").IgnoreCase);
        }

    }
}
