﻿using Repositories;
using Repositories.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinIT.Resourses.ViewModels.Tabs
{
    public class CSharpTabViewModel : BaseTabViewModel
    {
        public CSharpTabViewModel(CoursesRepository coursesRepository) : base(coursesRepository)
        {
        }
    }
}
