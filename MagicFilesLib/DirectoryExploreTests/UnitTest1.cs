using System;
using System.Collections.Generic;
using MagicFilesLib;
using Moq;
using NUnit.Framework;

namespace DirectoryExploreTests
{
    [TestFixture]
    public class UnitTest1
    {
        private Mock<IDirectoryExplorer> _directoryReader;
        
        private readonly string _file1 = "file.txt";
        private readonly string _file2 = "file2.txt";


        [OneTimeSetUp]
        public void SetUp()
        {
            _directoryReader = new Mock<IDirectoryExplorer>();   
        }
        [Test]
        [TestCase("C:/Users/HP/Desktop")]
        public void TestMethod1(string path)
        {
            _directoryReader.Setup(dr => dr.GetFiles(It.IsAny<string>())).Returns(()=>new List<string> { _file1, _file2 });

            var result = _directoryReader.Object.GetFiles(path);

            Assert.NotNull(result);
            Assert.IsTrue(result.Count == 2);
            Assert.That(result, Contains.Item(_file1));

            
        }
    }
}
