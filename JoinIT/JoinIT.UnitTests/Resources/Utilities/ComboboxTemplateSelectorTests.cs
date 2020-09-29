using System.Collections.Generic;
using System.Windows;
using JoinIT.Resources.ITLocalData;
using JoinIT.Resources.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JoinIT.UnitTests.Resources.Utilities
{
    [TestClass]
    public class ComboboxTemplateSelectorTests
    {
        private ComboboxTemplateSelector _comboboxTemplateSelector;

        [TestInitialize]
        public void TestInitialize()
        {
            _comboboxTemplateSelector = new ComboboxTemplateSelector();
        }

        [DataTestMethod]
        [DataRow("CourseName")]
        [DataRow("AuthorName")]
        public void GetProperTemplateName_WhenTextName_ReturnsDataTemplateName(string comboboxTemplateKey)
        {
            //Arrange

            //Act

            var result = _comboboxTemplateSelector.GetProperTemplateName(comboboxTemplateKey);

            //Assert

            Assert.AreEqual(ITConstants.NamesTemplate, result);
        }

        [DataTestMethod]
        [DataRow("StartDate")]
        [DataRow("EndDate")]
        public void GetProperTemplateName_WhenDateName_ReturnsDataTemplateName(string comboboxTemplateKey)
        {
            //Arrange

            //Act

            var result = _comboboxTemplateSelector.GetProperTemplateName(comboboxTemplateKey);

            //Assert

            Assert.AreEqual(ITConstants.DatesTemplate, result);
        }

        [TestMethod]
        public void GetProperTemplateName_WhenDateName_ReturnsDataTemplateName()
        {
            //Arrange

            //Act

            var result = _comboboxTemplateSelector.GetProperTemplateName(null);

            //Assert

            Assert.IsNull(result);
        }

        [DataTestMethod]
        [DataRow("SomeTest", "Some Test")]
        public void SelectTemplate_BadKeyValuePairPassed_ReturnsNull(string propertyName, string actualName)
        {
            //Arrange

            DependencyObject dependencyObject = new DependencyObject();
            KeyValuePair<string, string> courseModelNameKeyValuePair = new KeyValuePair<string, string>(propertyName, actualName);

            //Act

            var result = _comboboxTemplateSelector.SelectTemplate(courseModelNameKeyValuePair, dependencyObject);

            //Assert

            Assert.IsNull(result);

        }
    }
}
