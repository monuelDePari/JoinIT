namespace JoinIT.Resources.Views
{
    using JoinIT.Resources.Utilities;
    using JoinIT.Resources.ViewModels;
    using JoinIT.Resources.Views.TabsView;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using Unity;

    /// <summary>
    /// Interaction logic for StartupView.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class StartupView : Window
    {
        public StartupView()
        {
            InitializeComponent();

            DataContext = ITUnityContainer.Instance.Resolve<StartupViewModel>();
        }

        private void LanguageSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            LanguageView languageTabView = new LanguageView();
            languageTabView.Show();
        }
    }
}
