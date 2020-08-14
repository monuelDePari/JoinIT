namespace JoinIT
{
    using JoinIT.Resourses.Utilities;
    using JoinIT.Resourses.ViewModels;
    using JoinIT.Resourses.Views;
    using Repositories;
    using Repositories.Instructions;
    using System.Windows;
    using Unity;
    using Unity.Injection;
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUnityContainer unityContainer = ITUnityContainer.GetInstance.RegisterType<ICoursesRepository, CoursesRepository>();

            var startupViewModel = ITUnityContainer.GetInstance.Resolve<StartupViewModel>();
            var window = new Startup { DataContext = startupViewModel };
            window.Show();
        }
    }
}
