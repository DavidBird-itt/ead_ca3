using Microsoft.VisualStudio.TestTools.UnitTesting;
using ca3Pages;
using System.Net.Http;
using System.Net.Http.Json;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async void TestParseData()
        {
            var Http = new HttpClient();

            Root data;
            string uri = "https://api.openweathermap.org/data/2.5/weather?q=dublin&appid=b14c995566a1eb4fb31557124f720a82";
            data = await Http.GetFromJsonAsync<ca3Pages.Root>(uri);

            Assert.AreEqual("Dublin", data.name);
        }

        [TestMethod]
        public void TestCelsiusCalc()
        {
            double k = 286.4;
            double celcius = 13.25;

            double c = k - 273.15;

            Assert.AreEqual(celcius, c);
        }

        [TestMethod]
        public void TestFahrenheit()
        {
            double k = 286.34;
            double fahrenheit = 56.01;

            double f = (1.8 * (k - 273)) + 32;

            f = Math.Round(f, 2);

            Assert.AreEqual(fahrenheit, f);
        }
    }
}
