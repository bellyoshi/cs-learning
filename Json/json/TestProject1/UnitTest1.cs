using Newtonsoft.Json;
using System.Drawing;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Color c = Color.FromArgb(255, 0, 255);
            var d = c;
            Assert.AreEqual(255, d.R);
            Assert.AreEqual(0, d.G);
            Assert.AreEqual(255, d.B);

        }

        [TestMethod]
        public void TestMethod2()
        {
            Color c = Color.FromArgb(250,0,250);
            string json = JsonConvert.SerializeObject(c);
            var d = JsonConvert.DeserializeObject<Color>(json);
            Assert.AreEqual(250, d.R);
            Assert.AreEqual(0, d.G);
            Assert.AreEqual(250, d.B);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Color c = Color.FromArgb(250, 0, 250);
            string json = System.Text.Json.JsonSerializer.Serialize(c);
            var d = System.Text.Json.JsonSerializer.Deserialize<Color>(json);
            Assert.AreEqual(250, d.R);
            Assert.AreEqual(0, d.G);
            Assert.AreEqual(250, d.B);
        }
    }
}