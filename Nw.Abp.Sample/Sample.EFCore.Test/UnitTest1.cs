using NUnit.Framework;
using Sample.Common.JwtHelpers;
using System.IO;

namespace Sample.EFCore.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            RSAHelper.GenerateAndSaveKey(Directory.GetCurrentDirectory());
            Assert.Pass();
        }
    }
}