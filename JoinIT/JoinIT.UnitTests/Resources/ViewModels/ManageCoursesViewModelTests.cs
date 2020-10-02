using System;
using System.Threading.Tasks;
using JoinIT.Resources.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using Repositories.Instructions;

namespace JoinIT.UnitTests.Resources.ViewModels
{
    [TestClass]
    public class ManageCoursesViewModelTests : BaseTestsClass
    {
        private ManageCoursesViewModel GetViewModel(Mock<ICoursesRepository> repositoryMock = null, CourseInfoModel courseModel = null)
        {
            return new ManageCoursesViewModel(repositoryMock != null
                    ? repositoryMock.Object
                    : GetCoursesRepository().Object, courseModel != null
                ? courseModel
                : new CourseInfoModel());
        }

        [TestMethod]
        public async Task SaveCourseAsync_WhenAdding_StorageWasCalled()
        {
            //Arrange
            var repositoryMock = GetCoursesRepository();

            var manageCoursesViewModel = GetViewModel(repositoryMock);

            //Act
            await manageCoursesViewModel.SaveCommand.ExecuteAsync(null);

            //Assert
            repositoryMock.Verify(t => t.AddAsync(It.IsAny<CourseInfoModel>()));
        }

        [TestMethod]
        public async Task SaveCourseAsync_WhenUpdating_StorageWasCalled()
        {
            //Arrange
            var repositoryMock = GetCoursesRepository();
            var courseModel = new CourseInfoModel
            {
                Id = 999,
                CourseName = "CPlusPlus",
                AuthorName = "Roman",
                StartDate = new DateTime(2000, 1,1),
                EndDate = new DateTime(2000, 1, 1)
            };
            var manageCoursesViewModel = GetViewModel(repositoryMock, courseModel);

            //Act
            await manageCoursesViewModel.SaveCommand.ExecuteAsync(null);

            //Assert
            repositoryMock.Verify(t => t.UpdateAsync(It.IsAny<CourseInfoModel>()));
        }
    }
}
