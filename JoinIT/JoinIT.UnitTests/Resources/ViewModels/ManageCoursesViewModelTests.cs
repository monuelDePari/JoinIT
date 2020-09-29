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


        [DataTestMethod]
        [DataRow("CPlusPlus", "Roman")]
        public async Task SaveCourseAsync_IsAdding_AddEntityToDatabase(string courseName, string authorName)
        {
            //Arrange

            var courseInfoModel = new CourseInfoModel();

            Mock<ICoursesRepository> repositoryMock = GetCoursesRepository();
            repositoryMock.Setup(t => t.AddAsync(It.IsAny<CourseInfoModel>()));

            ManageCoursesViewModel manageCoursesViewModel = GetViewModel(repositoryMock);
            manageCoursesViewModel.CourseModel.CourseName = courseName;
            manageCoursesViewModel.CourseModel.AuthorName = authorName;
            manageCoursesViewModel.CourseModel.StartDate = new DateTime(2000, 1, 1);
            manageCoursesViewModel.CourseModel.EndDate = new DateTime(2000, 1, 1);
            

            //Act

            await manageCoursesViewModel.SaveCommand.ExecuteAsync(null);

            //Assert

            repositoryMock.Verify(t => t.AddAsync(courseInfoModel));
        }
    }
}
