using System;
using System.Reflection;
using Microsoft.Owin.Host.HttpListener;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorld.Tests
{
    [CodedUITest]
    public class MainWindowUITest
    {
        private ApplicationUnderTest _api;
        private ApplicationUnderTest _aut;

        [TestInitialize]
        public void TestInitialize()
        {
            Assembly.GetAssembly(typeof(OwinHttpListener));
            _api = ApplicationUnderTest.Launch(
                typeof(Startup).Assembly.ManifestModule.Name);
            _aut = ApplicationUnderTest.Launch(
                typeof(MainWindow).Assembly.ManifestModule.Name);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _aut.Close();
            _api.Close();
        }

        [TestMethod]
        public void WhenClickGetMessageButtonThenSetsMessageText()
        {
            // Arrange
            this.UIMap.ClearMessageText();

            // Act
            this.UIMap.ClickGetMessageButton();
            this.UIMap.UIHelloWorldWindow.UIMessageTextBoxEdit
                .WaitForControlPropertyNotEqual("Text",
                    this.UIMap.ClearMessageTextParams.UIMessageTextBoxEditText,
                    millisecondsTimeout: 3000);

            // Assert
            Assert.AreEqual("Hello World",
                this.UIMap.UIHelloWorldWindow.UIMessageTextBoxEdit.Text);
        }

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
