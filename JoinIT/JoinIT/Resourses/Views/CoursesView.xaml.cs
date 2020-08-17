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

            ITUnityContainer.GetInstance.RegisterType<DbContext, ITContext>(new PerThreadLifetimeManager());

            ITUnityContainer.GetInstance.RegisterType<ICoursesRepository, CoursesRepository>(new InjectionConstructor(new ITContext()));

            DataContext = ITUnityContainer.GetInstance.Resolve<CoursesTabViewModel>();

            Loaded += CoursesTab_Loaded;
        }

        private async void CoursesTab_Loaded(object sender, RoutedEventArgs e)
        {
            var coursesTabViewModel = (CoursesTabViewModel)DataContext;
            await coursesTabViewModel.LoadDataAsync();
        }
    }
}
