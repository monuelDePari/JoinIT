using JoinIT.Resources.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace JoinIT.UnitTests.Resources.Utilities
{
    [TestClass]
    public class CourseInfoModelExtensionTests
    {
        private CourseInfoModel _courseInfoModel;

        [TestInitialize]
        public void CourseInfoModelExtensionTestsInitialize()
        {
            _courseInfoModel = new CourseInfoModel();
        }

        [DataTestMethod]
        [DataRow("CourseName")]
        public void GetPropertyName_WhenNameGiven_ReturnsPropertyName(string propertyName)
        {
            //Arrange

            //Act

            var result = _courseInfoModel.GetPropertyName(t => t.CourseName);

            //Assert

            Assert.AreEqual(propertyName, result);
        }

        [TestMethod]
        public void GetPropertyName_WhenNoPropertyNameGiven_ReturnsNull()
        {
            //Arrange

            //Act

            var result = _courseInfoModel.GetPropertyName(t => t.ToString());

            //Assert

            Assert.IsNull(result);
        }
    }
}
