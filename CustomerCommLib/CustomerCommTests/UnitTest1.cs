using System;
using CustomerCommLib;
using Moq;
using NUnit.Framework;

namespace CustomerCommTests
{
    [TestFixture]
    public class UnitTest1
    {
        private Mock<IMailSender> _mailReader;
        private CustomeComm _mailService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _mailReader = new Mock<IMailSender>();
            _mailService = new CustomeComm(_mailReader.Object);
        }
        [Test]
        [TestCase("rishavsingh219@gmail.com","Hi,There Rishav")]
        public void SendMailToCustomer_WhenCalled_ReturnsTrue(string a,string b)
        {
            _mailReader.Setup(mr => mr.SendMail(a,b)).Returns(true);

            var result = _mailService.SendMailToCustomer();

            Assert.That(result, Is.True);
        }
    }
}
