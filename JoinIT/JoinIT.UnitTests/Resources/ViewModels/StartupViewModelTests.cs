using System;
using JoinIT.Resources.Utilities.Commands.Instructions;
using JoinIT.Resources.Utilities.Wrappers;
using JoinIT.Resources.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Events;

namespace JoinIT.UnitTests.Resources.ViewModels
{
    [TestClass]
    public class StartupViewModelTests : BaseTestsClass
    {
        private StartupViewModel GetViewModel(Mock<IITApplication> iItApplicationMock = null,
            Mock<IApplicationCommands> applicationCommandsMock = null,
            Mock<IEventAggregator> eventAggregatorMock = null)
        {
            return new StartupViewModel(
                applicationCommandsMock != null ? applicationCommandsMock.Object : GetApplicationCommands().Object,
                eventAggregatorMock != null ? eventAggregatorMock.Object : GetEventAggregator().Object,
                iItApplicationMock != null ? iItApplicationMock.Object : GetIITApplication().Object);
        }

        [TestMethod]
        public void OpenLanguageWindowCommand_WhenNoParameterPassed_RaisedEvent()
        {
            //Arrange
            string toTest = null;
            var startupViewModel = GetViewModel();
            startupViewModel.OpenLanguageWindowEventHandler += delegate (object sender, EventArgs e)
            {
                toTest = e.ToString();
            };

            //Act
            startupViewModel.OpenLanguageWindowCommand.Execute(null);

            //Assert
            Assert.IsNotNull(toTest);
        }

        [TestMethod]
        public void OpenCoursesWindowCommand_WhenNoParameterPassed_RaisedEvent()
        {
            //Arrange
            string toTest = null;
            var startupViewModel = GetViewModel();
            startupViewModel.OpenCoursesWindowEventHandler += delegate (object sender, EventArgs e)
            {
                toTest = e.ToString();
            };

            //Act
            startupViewModel.OpenCoursesWindowCommand.Execute(null);

            //Assert
            Assert.IsNotNull(toTest);
        }


    }
}
