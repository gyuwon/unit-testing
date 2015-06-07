using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorld.Tests
{
    [TestClass]
    public class MessageApiTest
    {
        [TestMethod]
        public async Task GetMessageApiRespondsMessage()
        {
            // Arrange
            var server = TestServer.Create<Startup>();
            var uri = "http://localhost:9000/api/message";

            // Act
            var response = await server.HttpClient.GetAsync(uri);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsAsync<dynamic>();
            string message = content.Message;
            Assert.AreEqual("Hello World", message);
        }
    }
}
