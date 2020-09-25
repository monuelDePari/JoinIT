using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using Repositories;

namespace JoinIT.UnitTests.Repositories.Repository
{
    [TestClass]
    public class BaseRepositoryTests
    {
        [TestMethod]
        public void FindAsync_CourseInfoModelEntityFindInDatabaseById_ReturnsListOfCourseInfoModelsWrappedInTask()
        {
            //Arrange

            var dbContext = new ITContext();
            var courseInfoModel = new CourseInfoModel();
            var baseRepository = new BaseRepository<CourseInfoModel>(dbContext);

            //Act

            var result = baseRepository.FindAsync(t => t.Id == courseInfoModel.Id);

            //Assert

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UpdateAsync_UpdateCourseInfoModel_ReturnChangesInTheDatabaseAsATask()
        {
            //Arrange

            var dBContextMock = new Mock<ITContext>();
            var courseInfoModel = new CourseInfoModel();
            var baseRepository = new BaseRepository<CourseInfoModel>(dBContextMock.Object);
            //Act

            var result = baseRepository.UpdateAsync(courseInfoModel);

            //Assert

            Assert.IsNotNull(result);
        }
    }
}
