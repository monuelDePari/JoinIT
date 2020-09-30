using JoinIT.Resources.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;

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

        [TestCleanup]
        public void CourseInfoModelExtensionTestsCleanUp()
        {
            _courseInfoModel = null;
        }

        [TestMethod]
        public void GetPropertyName_WhenNameGiven_ReturnsPropertyName()
        {
            //Arrange

            var propertyName = nameof(CourseInfoModel.CourseName);

            //Act

            var result = _courseInfoModel.GetPropertyName(t => t.CourseName);

            //Assert

            Assert.AreEqual(propertyName, result);
        }

        [TestMethod]
        public void GetPropertyName_WhenWrongExpressionGiven_ReturnsNull()
        {
            //Arrange
            
            var propertyName = "CourseName";
            var propertyNameToCompare = It.IsAny<string>();

            //Act

            var result = _courseInfoModel.GetPropertyName(t => propertyName == propertyNameToCompare);

            //Assert

            Assert.IsNull(result);
        }
    }
}
