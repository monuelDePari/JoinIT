using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using JoinIT.Resources.Enums;
using JoinIT.Resources.Utilities;
using JoinIT.Resources.ViewModels.TabsViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using Prism.Events;
using Repositories.Instructions;

namespace JoinIT.UnitTests.Resources.ViewModels.TabsViewModels
{
    [TestClass]
    public class BaseTabViewModelTests : BaseTestsClass
    {
        private BaseTabViewModel GetViewModel(Mock<ICoursesRepository> repositoryMock = null,
            Mock<IApplicationCommands> applicationCommandsMock = null,
            Mock<IEventAggregator> eventAggregatorMock = null)
        {
            return new BaseTabViewModel(repositoryMock != null
                    ? repositoryMock.Object
                    : GetCoursesRepository().Object,
                applicationCommandsMock != null ? applicationCommandsMock.Object : GetApplicationCommands().Object,
                eventAggregatorMock != null ? eventAggregatorMock.Object : GetEventAggregator().Object);

        }

        [TestMethod]
        public void CourseInfoModelsListOfPropertiesToDictionary_ListToDictionary_ReturnsCourseInfoModelCollection()
        {
            //Arrange

            var baseTabViewModel = GetViewModel();

            //Act

            var result = baseTabViewModel.CourseInfoModelsListOfPropertiesToDictionary();

            //Assert

            Assert.IsInstanceOfType(result, typeof(Dictionary<string, string>));
        }

        [DataTestMethod]
        [DataRow(CourseNames.CPlusPlus)]
        [DataRow(CourseNames.CSharp)]
        [DataRow(CourseNames.Java)]
        public async Task LoadDataAsync_WhenCalledForDifferentTabs_StorageWasCalled(CourseNames courseName)
        {
            //Arrange
            var courseInfoModels = new List<CourseInfoModel>();

            var repositoryMock = GetCoursesRepository();
            repositoryMock.Setup(s => s.FindAsync(It.IsAny<Expression<Func<CourseInfoModel, bool>>>()))
                .ReturnsAsync(courseInfoModels);

            var baseTabViewModel = GetViewModel(repositoryMock);

            //Act
            await baseTabViewModel.LoadDataAsync(courseName.ToString());

            //Assert
            repositoryMock.Verify(s => s.FindAsync(It.IsAny<Expression<Func<CourseInfoModel, bool>>>()));
            Assert.AreEqual(baseTabViewModel.CourseInfoModels, courseInfoModels);
        }

        [TestMethod]
        public void OnDeletedCoursesChangedAsync_CanExecute_WhenAdding_ReturnsTrue()
        {
            //Arrange

            var baseTabViewModel = new BaseTabViewModel()
            {
                SelectedCoursesInfoModels = new List<object>(),
                IsLoading = false
            };

            //Act

            var result = baseTabViewModel.DeleteSelectedCoursesCommand.CanExecute(It.IsAny<object>());

            //Assert

            Assert.IsTrue(result);

        }

        [DataTestMethod]
        [DataRow("StartDate", "Start Date")]
        public async Task
            OnSelectedDateChangedAsync_StartDateChanged_ReturnsCourses(string startDate, string startDateWithWhitespace)
        {
            //Arrange

            var courseInfoModels = new List<CourseInfoModel>();

            var repositoryMock = GetCoursesRepository();
            repositoryMock.Setup(t => t.FindAsync(It.IsAny<Expression<Func<CourseInfoModel, bool>>>()))
                .ReturnsAsync(courseInfoModels);

            var baseTabViewModel = GetViewModel(repositoryMock);
            baseTabViewModel.CourseInfoModels = courseInfoModels;
            baseTabViewModel.CourseInfoModelKeyValuePair = new KeyValuePair<string, string>(startDate, startDateWithWhitespace);
            DateTime startDateTime = new DateTime(2020, 1, 1);

            //Act

            await baseTabViewModel.SelectedDateChangedCommand.ExecuteAsync(startDateTime);

            //Assert

            repositoryMock.Verify(t => t.FindAsync(It.IsAny<Expression<Func<CourseInfoModel, bool>>>()));
        }

        [TestMethod]
        public async Task
            OnDeletedCoursesChangedAsync_DeleteSelectedCourses_ReturnsCourses()
        {
            //Arrange

            var repositoryMock = GetCoursesRepository();
            repositoryMock.Setup(t => t.RemoveRangeAsync(It.IsAny<List<CourseInfoModel>>()));

            var baseTabViewModel = GetViewModel(repositoryMock);

            var selectedCourseInfoModel = new CourseInfoModel();

            var selectedCourseInfoModels = new List<CourseInfoModel>(){ selectedCourseInfoModel };

            baseTabViewModel.CourseInfoModels = new List<CourseInfoModel>() { selectedCourseInfoModel };
            baseTabViewModel.SelectedCoursesInfoModels = new List<object>() { selectedCourseInfoModel };

            //Act

            await baseTabViewModel.DeleteSelectedCoursesCommand.ExecuteAsync(null);

            //Assert

            repositoryMock.Verify(t => t.RemoveRangeAsync(selectedCourseInfoModels));
        }
    }
}
