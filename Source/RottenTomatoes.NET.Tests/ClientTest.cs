using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RottenTomatoes.Net45.Test
{
    [TestFixture]
    public abstract class ClientTest
    {
        public ClientTest()
        {
            ApiKey = File.ReadAllText("RottenTomatoesKey.txt");
            Client = new RottenTomatoesClient(ApiKey);
        }

        public string ApiKey;

        public RottenTomatoesClient Client { get; private set; }

        public void IsNotNull(object o)
        {
            Assert.IsNotNull(o);
        }
    }
}
