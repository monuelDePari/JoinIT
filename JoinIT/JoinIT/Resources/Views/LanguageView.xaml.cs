namespace JoinIT.Resources.Views
{
    using Utilities;
    using ViewModels.TabsViewModels;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using System.Windows;
    using System.Diagnostics;
    using Unity;
    using System;

    /// <summary>
    /// Interaction logic for LanguageTabView.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class LanguageView
    {
        private readonly LanguageViewModel _languageViewModel;
        public LanguageView()
        {
            InitializeComponent();

            DataContext = ITUnityContainer.Instance.Resolve<LanguageViewModel>();

            _languageViewModel = (LanguageViewModel)DataContext;

            Loaded += LanguageView_OnLoaded;
            Closed += LanguageView_OnClosed;
            _languageViewModel.RestartAppEvenHandler += OnAppRestart;
        }

        private void OnAppRestart(object sender, EventArgs e)
        {
            if(MessageBox.Show(Properties.Resources.AppRestart, Assembly.GetEntryAssembly().GetName().Name, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
        }

        private void LanguageView_OnLoaded(object sender, RoutedEventArgs e)
        {
            _languageViewModel.PropertyChanged += _languageViewModel.LanguageTabViewModelOnPropertyChanged;
        }

        private void LanguageView_OnClosed(object sender, EventArgs e)
        {
            _languageViewModel.PropertyChanged -= _languageViewModel.LanguageTabViewModelOnPropertyChanged;
            _languageViewModel.RestartAppEvenHandler -= OnAppRestart;
        }
    }
}
