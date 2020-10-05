using System;
using System.ComponentModel;
using JoinIT.Resources.Utilities.Commands.Instructions;
using JoinIT.Resources.Utilities.Extensions;
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
        public void OnCustomPropertyChanged_Always_FontSizeChanged()
        {
            //Arrange
            var startupViewModel = GetViewModel();
            var fontSizePropertyChangedEventArgs = new PropertyChangedEventArgs(startupViewModel.GetPropertyName(t => t.SelectedFontSize));
            var application = (IITApplication)new PrivateObject(startupViewModel).GetField("_application");

            //Act
            startupViewModel.OnCustomPropertyChanged(null, fontSizePropertyChangedEventArgs);
            var result = (int)application.FontSize;

            //Assert
            Assert.AreEqual(result, startupViewModel.SelectedFontSize);
        }

        [TestMethod]
        public void OpenLanguageWindowCommand_WhenNoParameterPassed_RaisedEvent()
        {
            //Arrange
            EventArgs actual = null;
            var startupViewModel = GetViewModel();
            startupViewModel.OpenLanguageWindowEventHandler += delegate (object sender, EventArgs e)
            {
                actual = e;
            };

            //Act
            startupViewModel.OpenLanguageWindowCommand.Execute(null);

            //Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void OpenCoursesWindowCommand_WhenNoParameterPassed_RaisedEvent()
        {
            //Arrange
            EventArgs actual = null;
            var startupViewModel = GetViewModel();
            startupViewModel.OpenCoursesWindowEventHandler += delegate (object sender, EventArgs e)
            {
                actual = e;
            };

            //Act
            startupViewModel.OpenCoursesWindowCommand.Execute(null);

            //Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void OpenCoursesWindowCommand_CanExecute_Always_ReturnsTrue()
        {
            //Arrange
            var startupViewModel = GetViewModel();
            startupViewModel.OpenCoursesWindowEventHandler += (o, e) => { };

            //Act
            var result = startupViewModel.OpenCoursesWindowCommand_CanExecute();

            //Assert
            Assert.IsTrue(result);
        }
    }
}
