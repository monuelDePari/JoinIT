using JoinIT.Resourses.ViewModels.TabsViewModels;
using Moq;
using NUnit.Framework;
using Repositories.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinITUnitTests.Resources.NewFolder1.ViewModels
{
    [TestFixture]
    class ITBaseTabViewModelTest
    {
        [Test]
        public void LoadData_WithCorrectCourseName_ReturnsCoursesWithProperFilterAsync()
        {
            string courseName = "CPlusPlus";
            Mock<ICoursesRepository> mockICoursesRepository = new Mock<ICoursesRepository>();
            ITBaseTabViewModel iTBaseTabViewModel = new ITBaseTabViewModel(mockICoursesRepository.Object);

            Assert.IsNotNull(iTBaseTabViewModel.LoadDataAsync(courseName));
        }
    }
}
