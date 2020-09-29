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
        public async Task SaveCourseAsync_IsAdding_AddEntityToDatabase()
        {
            //Arrange

            Mock<ICoursesRepository> repositoryMock = GetCoursesRepository();
            repositoryMock.Setup(t => t.AddAsync(It.IsAny<CourseInfoModel>()));

            ManageCoursesViewModel manageCoursesViewModel = GetViewModel(repositoryMock);

            //Act

            await manageCoursesViewModel.SaveCommand.ExecuteAsync(null);

            //Assert

            repositoryMock.Verify(t => t.AddAsync(It.IsAny<CourseInfoModel>()));
        }

        [TestMethod]
        public async Task SaveCourseAsync_Isupdating_UpdateEntityInDatabase()
        {
            //Arrange

            Mock<ICoursesRepository> repositoryMock = GetCoursesRepository();
            repositoryMock.Setup(t => t.UpdateAsync(It.IsAny<CourseInfoModel>()));

            ManageCoursesViewModel manageCoursesViewModel = GetViewModel(repositoryMock, new CourseInfoModel());

            //Act

            await manageCoursesViewModel.SaveCommand.ExecuteAsync(null);

            //Assert

            repositoryMock.Verify(t => t.AddAsync(It.IsAny<CourseInfoModel>()));
        }
    }
}
