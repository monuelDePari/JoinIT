using JoinIT.Resources.Utilities.Extensions;
using JoinIT.Resources.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;

namespace JoinIT.UnitTests.Resources.Utilities.Extensions
{
    [TestClass]
    public class CourseInfoModelExtensionTests
    {
        [TestMethod]
        public void GetPropertyName_WhenNameGiven_ReturnsPropertyName()
        {
            //Arrange
            var propertyName = nameof(CourseInfoModel.CourseName);
            var courseInfoModel = TestHelper<CourseInfoModel>.GetInstance<CourseInfoModel>();

            //Act
            var result = courseInfoModel.GetPropertyName(t => t.CourseName);

            //Assert
            Assert.AreEqual(propertyName, result);
        }

        [TestMethod]
        public void GetPropertyName_WhenWrongExpressionGiven_ReturnsNull()
        {
            //Arrange
            var propertyNameToCompare = It.IsAny<CourseInfoModel>();
            var courseInfoModel = TestHelper<CourseInfoModel>.GetInstance<CourseInfoModel>();

            //Act
            var result = courseInfoModel.GetPropertyName(t => t.CourseName == propertyNameToCompare.CourseName);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetConstructorParameterName_Always_ReturnsParameterName()
        {
            //Arrange
            var expectedResult = "courseModel";
            var courseInfoModel = TestHelper<CourseInfoModel>.GetInstance<CourseInfoModel>();

            //Act
            var result = courseInfoModel.GetConstructorParameterName(typeof(ManageCoursesViewModel), 0, 1);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetConstructorParameterName_WhenBadParameterIndex_ReturnsNull()
        {
            //Arrange
            var courseInfoModel = TestHelper<CourseInfoModel>.GetInstance<CourseInfoModel>();

            //Act
            var result = courseInfoModel.GetConstructorParameterName(typeof(ManageCoursesViewModel), 0, 5);

            //Assert
            Assert.IsNull(result);
        }
    }
}
