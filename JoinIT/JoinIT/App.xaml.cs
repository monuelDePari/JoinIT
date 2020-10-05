using JoinIT.Resources.Utilities.Services;

namespace JoinIT
{
    using Properties;
    using Resources.Utilities;
    using Resources.Views;
    using Repositories;
    using Repositories.Instructions;
    using System.Data.Entity;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using Unity.Lifetime;
    using Unity;
    using Resources.Utilities.Commands;
    using Resources.Utilities.Commands.Instructions;
    using Resources.Utilities.Services.Instructions;
    using Resources.Utilities.Wrappers;
    using Prism.Events;

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

            ITUnityContainer.Instance.RegisterInstance<IApplicationCommands>(new ApplicationCommands());

            ITUnityContainer.Instance.RegisterInstance<IEventAggregator>(new EventAggregator());

            ITUnityContainer.Instance.RegisterInstance<IITApplication>(new ITApplicationWrapper());

            ITUnityContainer.Instance.RegisterInstance<ICustomMessageService>(new CustomMessageService());

            ITUnityContainer.Instance.RegisterType<DbContext, ITContext>(new PerThreadLifetimeManager());

            ITUnityContainer.Instance.RegisterInstance<ICoursesRepository>(new CoursesRepository(new ITContext()));

            var window = new StartupView();
            window.Show();
        }
    }
}
