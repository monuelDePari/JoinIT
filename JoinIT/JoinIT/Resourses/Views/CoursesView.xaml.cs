namespace JoinIT.Resourses.Views
{
    using JoinIT.Resourses.Enums;
    using JoinIT.Resourses.Utilities;
    using JoinIT.Resourses.ViewModels.TabsViewModels;
    using Repositories;
    using Repositories.Instructions;
    using Repositories.Repository;
    using System;
    using System.Data.Entity;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;
    using Unity;
    using Unity.Injection;
    using Unity.Lifetime;

    /// <summary>
    /// Interaction logic for CoursesView.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class CoursesView : UserControl
    {
        public CoursesView()
        {
            InitializeComponent();

            DataContext = ITUnityContainer.GetInstance.Resolve<CoursesTabViewModel>();
        }
    }
}
