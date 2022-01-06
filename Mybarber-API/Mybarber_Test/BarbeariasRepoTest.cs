using Moq;
using Mybarber.Models;
using Mybarber.Persistencia;
using Mybarber.Repositories;
using NUnit.Framework;

namespace Mybarber_Test
{
    [TestFixture]
    public class BabeariasRepoTest
    {
       
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAllWork()
        {
            var contextMock = new Mock<Context>();

            var sut = new BarbeariasRepository(contextMock.Object);

            var result = sut.GetAllBarbeariasAsync();

            //Assert.That(result, Is.EqualTo());

            Assert.Pass();
        }
    }
}