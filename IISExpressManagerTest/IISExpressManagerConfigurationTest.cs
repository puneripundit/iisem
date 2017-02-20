
using IISExpressManager;
using IISExpressManager.Helpers;
using NUnit.Framework;

namespace IISExpressManagerTest
{
    [TestFixture]
    class IISExpressManagerConfigurationTest
    {
        private IISExpressConfiguration iisExpressConfiguration;

        [SetUp]
        public void Init()
        {
            iisExpressConfiguration = new IISExpressConfiguration();
            
        }

        [Test]
        public void IISConfigExistenceTest()
        {
            Assert.AreEqual(true,
                iisExpressConfiguration.ConfigurationFound());
        }

        [Test]
        public void IISExpressExistenceTest()
        {
            Assert.AreEqual(true,iisExpressConfiguration.IISExpressInstalled());
        }

    }
}
