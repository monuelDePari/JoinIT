using JoinIT.Resources.Utilities.Commands.Instructions;
using JoinIT.Resources.Utilities.Services.Instructions;
using JoinIT.Resources.Utilities.Wrappers;
using Moq;
using Prism.Events;
using Repositories.Instructions;

namespace JoinIT.UnitTests
{
    public class BaseTestsClass
    {
        protected Mock<ICoursesRepository> GetCoursesRepository()
        {
            return new Mock<ICoursesRepository>();
        }

        protected Mock<IEventAggregator> GetEventAggregator()
        {
            return new Mock<IEventAggregator>();
        }

        protected Mock<IApplicationCommands> GetApplicationCommands()
        {
            return new Mock<IApplicationCommands>();
        }

        protected Mock<IITApplication> GetIITApplication()
        {
            return new Mock<IITApplication>();
        }

        protected Mock<ICustomMessageService> GetMessageService()
        {
            return new Mock<ICustomMessageService>();
        }
    }
}