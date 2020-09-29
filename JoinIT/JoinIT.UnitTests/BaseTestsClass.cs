using JoinIT.Resources.Utilities;
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
    }
}