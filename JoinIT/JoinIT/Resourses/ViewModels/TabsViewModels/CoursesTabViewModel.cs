using JoinIT.Resourses.ViewModels.Instructions;
using System;
using System.Windows.Input;

namespace JoinIT.Resourses.ViewModels.TabsViewModels
{
    public class CoursesTabViewModel : ICoursesTab
    {
        #region Constructors
        public CoursesTabViewModel()
        {
            CloseCommand = new RelativeCommand(p => CloseRequested.Invoke(this, EventArgs.Empty));
        }
        #endregion

        #region Commands
        public ICommand CloseCommand { get; private set; }
        #endregion

        #region Events
        public event EventHandler CloseRequested;
        #endregion
    }
}
