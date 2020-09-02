namespace JoinIT.Resources.Views
{
    using JoinIT.Resources.Utilities;
    using JoinIT.Resources.ViewModels.TabsViewModels;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using System.Windows;
    using Unity;

    /// <summary>
    /// Interaction logic for LanguageTabView.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class LanguageView : Window
    {
        public LanguageView()
        {
            InitializeComponent();

            DataContext = ITUnityContainer.Instance.Resolve<LanguageViewModel>();

            Loaded += LanguageView_OnLoaded;
            Unloaded += LanguageView_OnClosed;
        }

        private void LanguageView_OnLoaded(object sender, RoutedEventArgs e)
        {
            var languageTabViewModel = (LanguageViewModel)DataContext;
            languageTabViewModel.SubscribePropertyChanged();
        }

        private void LanguageView_OnClosed(object sender, RoutedEventArgs e)
        {
            var languageTabViewModel = (LanguageViewModel)DataContext;
            languageTabViewModel.DisposePropertyChanged();

            MessageBox.Show(Properties.Resources.AppRestart, Assembly.GetEntryAssembly().GetName().Name, MessageBoxButton.OK);

            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}
