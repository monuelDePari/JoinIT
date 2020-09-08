namespace JoinIT
{
    using JoinIT.Properties;
    using JoinIT.Resources.Utilities;
    using JoinIT.Resources.Views;
    using Models;
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

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Settings.Default.LanguageSetting);

            ITUnityContainer.Instance.RegisterType<ICoursesRepository, CoursesRepository>();

            ITUnityContainer.Instance.RegisterType<DbContext, ITContext>(new PerThreadLifetimeManager());

            ITUnityContainer.Instance.RegisterType<ICoursesRepository, CoursesRepository>(new InjectionConstructor(new ITContext()));

            var window = new StartupView();                
            window.Show();
        }
    }
}
