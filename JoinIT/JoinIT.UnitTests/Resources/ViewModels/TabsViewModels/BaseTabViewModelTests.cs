using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using JoinIT.Resources.Enums;
using JoinIT.Resources.Utilities.Commands.Instructions;
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
        public void ConvertPropertiesListToDictionary_Always_ReturnsCourseInfoModelsDictionary()
        {
            //Arrange
            var baseTabViewModel = GetViewModel();

            //Act
            var result = baseTabViewModel.ConvertPropertiesListToDictionary();

            //Assert
            Assert.IsNotNull(result);
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
            Assert.AreSame(baseTabViewModel.CourseInfoModels, courseInfoModels);
        }

        [TestMethod]
        public async Task LoadDataAsync_WhenWrongTabName_StorageWasCalled()
        {
            //Arrange
            var courseInfoModels = new List<CourseInfoModel>();
            var tabName = It.IsAny<string>();
            var repositoryMock = GetCoursesRepository();
            repositoryMock.Setup(s => s.FindAsync(It.IsAny<Expression<Func<CourseInfoModel, bool>>>()))
                .ReturnsAsync(courseInfoModels);

            var baseTabViewModel = GetViewModel(repositoryMock);

            //Act
            await baseTabViewModel.LoadDataAsync(tabName);

            //Assert
            repositoryMock.Verify(s => s.FindAsync(It.IsAny<Expression<Func<CourseInfoModel, bool>>>()));
            Assert.AreEqual(0, courseInfoModels.Count);
        }

        [TestMethod]
        public void DeleteSelectedCoursesCommand_CanExecute_WhenAdding_ReturnsTrue()
        {
            //Arrange
            var baseTabViewModel = GetViewModel();
            baseTabViewModel.SelectedCoursesInfoModels = new List<object>();

            //Act
            var result = baseTabViewModel.DeleteSelectedCoursesCommand.CanExecute(It.IsAny<object>());

            //Assert
            Assert.IsTrue(result);

        }
        [TestMethod]
        public async Task
            SelectedDateChangedCommand_WhenNoParameterPassed_ReturnsNull()
        {
            //Arrange
            var propertyName = It.IsAny<string>();
            var propertyNameWithWhitespace = It.IsAny<string>();

            var repositoryMock = GetCoursesRepository();
            var baseTabViewModel = GetViewModel(repositoryMock);

            baseTabViewModel.CourseInfoModels = new List<CourseInfoModel>();
            baseTabViewModel.CourseInfoModelKeyValuePair = new KeyValuePair<string, string>(propertyName, propertyNameWithWhitespace);

            //Act
            await baseTabViewModel.SelectedDateChangedCommand.ExecuteAsync(null);

            //Assert
            Assert.AreEqual(0, baseTabViewModel.CourseInfoModels.Count());
        }

        [DataTestMethod]
        [DataRow("CourseName", "Course Name")]
        [DataRow("AuthorName", "Author Name")]
        public async Task TextChangedCommand_WhenTextChanged_ReturnsCourses(string text, string textWithWhitespace)
        {
            //Arrange
            var courseInfoModels = new List<CourseInfoModel>();

            var repositoryMock = GetCoursesRepository();
            repositoryMock.Setup(t => t.FindAsync(It.IsAny<Expression<Func<CourseInfoModel, bool>>>()))
                .ReturnsAsync(courseInfoModels);

            var baseTabViewModel = GetViewModel(repositoryMock);
            baseTabViewModel.CourseInfoModelKeyValuePair = new KeyValuePair<string, string>(text, textWithWhitespace);

            //Act
            await baseTabViewModel.TextChangedCommand.ExecuteAsync(text);

            //Assert
            repositoryMock.Verify(t => t.FindAsync(It.IsAny<Expression<Func<CourseInfoModel, bool>>>()));

            Assert.AreSame(courseInfoModels, baseTabViewModel.CourseInfoModels);
        }

        [TestMethod]
        public async Task TextChangedCommand_WhenBadPropertyName_ReturnsNull()
        {
            //Arrange
            var courseInfoModels = new List<CourseInfoModel>();

            var propertyName = It.IsAny<string>();
            var propertyNameWithWhitespace = It.IsAny<string>();

            var repositoryMock = GetCoursesRepository();
            repositoryMock.Setup(t => t.FindAsync(It.IsAny<Expression<Func<CourseInfoModel, bool>>>()))
                .ReturnsAsync(courseInfoModels);

            var baseTabViewModel = GetViewModel(repositoryMock);
            baseTabViewModel.CourseInfoModelKeyValuePair = new KeyValuePair<string, string>(propertyName, propertyNameWithWhitespace);

            //Act
            await baseTabViewModel.TextChangedCommand.ExecuteAsync(propertyName);

            //Assert
            repositoryMock.Verify(t => t.FindAsync(It.IsAny<Expression<Func<CourseInfoModel, bool>>>()));

            Assert.AreEqual(0, baseTabViewModel.CourseInfoModels.Count());
        }

        [DataTestMethod]
        [DataRow("StartDate", "Start Date")]
        [DataRow("EndDate", "End Date")]
        public async Task
            SelectedDateChangedCommand_WhenDateChanged_ReturnsCourses(string date, string dateWithWhitespace)
        {
            //Arrange
            var courseInfoModels = new List<CourseInfoModel>();

            var repositoryMock = GetCoursesRepository();
            repositoryMock.Setup(t => t.FindAsync(It.IsAny<Expression<Func<CourseInfoModel, bool>>>()))
                .ReturnsAsync(courseInfoModels);

            var baseTabViewModel = GetViewModel(repositoryMock);
            baseTabViewModel.CourseInfoModelKeyValuePair = new KeyValuePair<string, string>(date, dateWithWhitespace);
            var startDateTime = new DateTime(2020, 1, 1);

            //Act
            await baseTabViewModel.SelectedDateChangedCommand.ExecuteAsync(startDateTime);

            //Assert
            repositoryMock.Verify(t => t.FindAsync(It.IsAny<Expression<Func<CourseInfoModel, bool>>>()));
            
            Assert.AreSame(courseInfoModels, baseTabViewModel.CourseInfoModels);
        }

        [TestMethod]
        public async Task
            DeleteSelectedCoursesCommand_WhenNoParameterPassed_StorageWasCalled()
        {
            //Arrange
            var repositoryMock = GetCoursesRepository();
            var baseTabViewModel = GetViewModel(repositoryMock);

            var selectedCourseInfoModel = new CourseInfoModel();
            var selectedCourseInfoModels = new List<CourseInfoModel> { selectedCourseInfoModel };

            baseTabViewModel.CourseInfoModels = new List<CourseInfoModel> { selectedCourseInfoModel };
            baseTabViewModel.SelectedCoursesInfoModels = new List<object> { selectedCourseInfoModel };

            //Act
            await baseTabViewModel.DeleteSelectedCoursesCommand.ExecuteAsync(null);

            //Assert
            repositoryMock.Verify(t => t.RemoveRangeAsync(selectedCourseInfoModels));
        }

        [TestMethod]
        public void SelectedCourseChangedCommand_WhenUpdating_RaisedEvent()
        {
            //Arrange
            EventArgs actual = null;
            var baseTabViewModel = GetViewModel();
            baseTabViewModel.UpdateCourseHandler += delegate(object sender, EventArgs e)
            {
                actual = e;
            };

            //Act
            baseTabViewModel.SelectedCourseChangedCommand.Execute(null);

            //Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void UpdateCommand_WhenNoParameterPassed_RaisedEvent()
        {
            //Arrange

            var actual = new CourseInfoModel();
            var baseTabViewModel = GetViewModel();
            baseTabViewModel.SelectedCourseModel = new CourseInfoModel();
            baseTabViewModel.UpdateCourseHandler += delegate (object sender, EventArgs e)
            {
                actual = (CourseInfoModel)sender;
            };

            //Act

            baseTabViewModel.UpdateCommand.Execute(null);

            //Assert

            Assert.AreSame(actual, baseTabViewModel.SelectedCourseModel);
        }

        [TestMethod]
        public void SelectedCoursesChangedCommand_WhenSelectionChanged_ReturnsSelectedCourses()
        {
            //Arrange
            var baseTabViewModel = GetViewModel();
            var actualCollection = new Collection<object>()
            {
                new CourseInfoModel()
            };

            //Act
            baseTabViewModel.SelectedCoursesChangedCommand.Execute(actualCollection);

            //Assert
            Assert.AreNotEqual(0, baseTabViewModel.SelectedCoursesInfoModels);
        }

        [TestMethod]
        public void SelectedCoursesChangedCommand_WhenNoParameterGiven_ReturnsNull()
        {
            //Arrange
            var baseTabViewModel = GetViewModel();

            //Act
            baseTabViewModel.SelectedCoursesChangedCommand.Execute(null);

            //Assert
            Assert.AreEqual(0,baseTabViewModel.SelectedCoursesInfoModels.Count());
        }
    }
}
