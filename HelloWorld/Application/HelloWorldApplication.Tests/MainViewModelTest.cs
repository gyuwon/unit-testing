using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorld.Tests
{
    [TestClass]
    public class MainViewModelTest
    {
        private class HelloWorldServiceAgentStub : HelloWorldServiceAgent
        {
            private readonly string _message;

            public HelloWorldServiceAgentStub(string message)
            {
                _message = message;
            }

            public override Task<string> GetMessageAsync()
            {
                return Task.FromResult(_message);
            }
        }

        [TestMethod]
        public void GetMessageCommandSetsMessageText()
        {
            // Arrange
            var message = string.Format("Hello World");
            var service = new HelloWorldServiceAgentStub(message);
            var sut = new MainViewModel(service);

            // Act
            sut.GetMessageCommand.Execute(null);

            // Assert
            Assert.AreSame(message, sut.MessageText);
        }
    }
}
