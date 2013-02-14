using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Threading.Tasks;

namespace UnitTestLibrary1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void 足し算テスト1()
        {
            var calc = new ClassLibrary1.Calc();
            var result = calc.Add(10, 2);
            Assert.AreEqual(12, result, "10 + 2は12になる");
        }

        [TestMethod]
        public async Task ネットからのデータ取得テスト()
        {
            var client = new System.Net.Http.HttpClient();
            var text = await client.GetStringAsync("http://www.yahoo.co.jp/");

            // 意図したデータが取得できているかの確認(以下の確認は適当です)
            Assert.AreNotEqual(text.Length, 0, "取得したテキストの長さは0にならない");
        }
    }
}
