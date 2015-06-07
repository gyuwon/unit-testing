using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HelloWorld.Tests
{
    [TestClass]
    public class MainViewModelTest
    {
        [TestMethod]
        public void GetMessageCommandSetsMessageText()
        {
            // Arrange
            var message = string.Format("Hello World");
            var service = Mock.Of<HelloWorldServiceAgent>(s =>
                s.GetMessageAsync() == Task.FromResult(message));
            var sut = new MainViewModel(service);

            // Act
            sut.GetMessageCommand.Execute(null);

            // Assert
            Mock.Get(service).Verify(s => s.GetMessageAsync(), Times.Once());
            Assert.AreSame(message, sut.MessageText);
        }
    }
}
