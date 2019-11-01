using IntegrationsTests.TestHelpers;
using NUnit.Framework;

namespace IntegrationsTests
{
    [SetUpFixture]
    public class SetUpFixture
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            TestServerHelper.StartTestServer();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            TestServerHelper.StopTestServer();
        }

    }
}
