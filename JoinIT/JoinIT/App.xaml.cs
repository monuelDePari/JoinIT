using Prism.Events;

namespace JoinIT
{
    using Properties;
    using Resources.Utilities;
    using Resources.Views;
    using Repositories;
    using Repositories.Instructions;
    using Repositories.Repository;
    using System.Data.Entity;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using Unity.Injection;
    using Unity.Lifetime;
    using Unity;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Settings.Default.LanguageSetting);

            ITUnityContainer.Instance.RegisterType<ICoursesRepository, CoursesRepository>();

            ITUnityContainer.Instance.RegisterInstance<IApplicationCommands>(new ApplicationCommands());

            ITUnityContainer.Instance.RegisterInstance<IEventAggregator>(new EventAggregator());

            ITUnityContainer.Instance.RegisterType<DbContext, ITContext>(new PerThreadLifetimeManager());

            ITUnityContainer.Instance.RegisterType<ICoursesRepository, CoursesRepository>(new InjectionConstructor(new ITContext()));

            var window = new StartupView();
            window.Show();
        }
    }
}
