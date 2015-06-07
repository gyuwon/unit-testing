using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorld.Tests
{
    [CodedUITest]
    public class MainWindowUITest
    {
        private ApplicationUnderTest _aut;

        [TestInitialize]
        public void TestInitialize()
        {
            _aut = ApplicationUnderTest.Launch(
                typeof(MainWindow).Assembly.ManifestModule.Name);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _aut.Close();
        }

        [TestMethod]
        public void WhenClickGetMessageButtonThenSetsMessageText()
        {
            // Arrange
            this.UIMap.ClearMessageText();

            // Act
            this.UIMap.ClickGetMessageButton();

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
