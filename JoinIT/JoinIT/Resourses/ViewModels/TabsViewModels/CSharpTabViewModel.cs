using Repositories;
using Repositories.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinIT.Resourses.ViewModels.TabsViewModels
{
    public class CSharpTabViewModel : BaseTabViewModel
    {
        #region constructors
        public CSharpTabViewModel(CoursesRepository coursesRepository) : base(coursesRepository)
        {
        }
        #endregion
    }
}
