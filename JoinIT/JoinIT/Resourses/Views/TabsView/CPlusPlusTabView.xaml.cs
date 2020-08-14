using JoinIT.Resourses.Enums;
using JoinIT.Resourses.Utilities;
using JoinIT.Resourses.ViewModels.Tabs;
using Models;
using Repositories;
using Repositories.Instructions;
using Repositories.Repository;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace JoinIT.Resourses.Views.TabsView
{
    /// <summary>
    /// Interaction logic for CPlusPlusTab.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class CPlusPlusTab
    {
        public CPlusPlusTab()
        {
            InitializeComponent();

            ITUnityContainer.GetInstance.RegisterType<DbContext, ITContext>(new PerThreadLifetimeManager());

            ITUnityContainer.GetInstance.RegisterType<ICoursesRepository, CoursesRepository>(new InjectionConstructor(new ITContext()));

            DataContext = ITUnityContainer.GetInstance.Resolve<CPlusPlusTabViewModel>();

            Loaded += CPlusPlusTab_Loaded;
        }

        private async void CPlusPlusTab_Loaded(object sender, RoutedEventArgs e)
        {
            var cPlusPlusViewModel = (CPlusPlusTabViewModel)DataContext;
            await cPlusPlusViewModel.LoadCPlusPlusDataAsync();
        }
    }
}
