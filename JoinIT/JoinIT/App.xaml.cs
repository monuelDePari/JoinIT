namespace JoinIT
{
    using JoinIT.Resourses.Utilities;
    using JoinIT.Resourses.ViewModels;
    using JoinIT.Resourses.Views;
    using Repositories;
    using Repositories.Instructions;
    using Repositories.Repository;
    using System.Data.Entity;
    using System.Windows;
    using Unity;
    using Unity.Injection;
    using Unity.Lifetime;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUnityContainer unityContainer = ITUnityContainer.GetInstance.RegisterType<ICoursesRepository, CoursesRepository>();

            ITUnityContainer.GetInstance.RegisterType<DbContext, ITContext>(new PerThreadLifetimeManager());

            ITUnityContainer.GetInstance.RegisterType<ICoursesRepository, CoursesRepository>(new InjectionConstructor(new ITContext()));

            var startupViewModel = ITUnityContainer.GetInstance.Resolve<StartupViewModel>();
            var window = new StartupView { DataContext = startupViewModel };
            window.Show();
        }
    }
}
