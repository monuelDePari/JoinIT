﻿namespace JoinIT.Resources.ViewModels.TabsViewModels
{
    using Repositories;


    public class CSharpTabViewModel : BaseTabViewModel
    {
        #region constructors
        public CSharpTabViewModel(CoursesRepository coursesRepository) : base(coursesRepository)
        {
        }
        #endregion
    }
}