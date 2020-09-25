using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JoinIT.Resources.ViewModels.TabsViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;

namespace JoinIT.UnitTests.Resources.ViewModels.TabsViewModels
{
    [TestClass]
    public class BaseTabViewModelTests
    {
        [TestMethod]
        public void CourseInfoModelsListOfPropertiesToDictionary_ConvertListOfCourseInfoModelsToDictionaryWithNames_ReturnsDictionaryWhereKeyIsCourseNameAndValueIsCourseNameWithWhitespace()
        {
            //Arrange

            BaseTabViewModel baseTabViewModel = new BaseTabViewModel();

            //Act

            var result = baseTabViewModel.CourseInfoModelsListOfPropertiesToDictionary();

            //Assert

            Assert.IsInstanceOfType(result, typeof(Dictionary<string, string>));
        }

        [TestMethod]
        public async Task LoadDataAsync_LoadAsynchronyousCourseInfoModelDataWhenCPlusPlusTabNamePassed_ReturnsCourseInfoModelsCollection()
        {
            //Arrange

            BaseTabViewModel baseTabViewModel = new BaseTabViewModel();
            baseTabViewModel.CourseInfoModels = new[] { new Mock<CourseInfoModel>().Object };

            const string TAB_NAME = "CPlusPlus";

            //Act

            await baseTabViewModel.LoadDataAsync(TAB_NAME);

            //Assert

            Assert.IsNotNull(baseTabViewModel.CourseInfoModels);

        }

        [TestMethod]
        public void OnDeletedCoursesChangedAsync_CanExecute_SelectedModelsAreNotNullAndIsLoadingIsFalse_ReturnsTrue()
        {
            //Arrange

            var baseTabViewModel = new BaseTabViewModel()
            {
                SelectedCoursesInfoModels = new[] {new Mock<CourseInfoModel>()},
                IsLoading = false
            };

            //Act

            var result = baseTabViewModel.OnDeletedCoursesChangedAsync_CanExecute(null);

            //Assert

            Assert.IsTrue(result);

        }
    }
}
