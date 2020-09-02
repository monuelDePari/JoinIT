namespace JoinIT.Resources.Views
{
    using JoinIT.Resources.Utilities;
    using JoinIT.Resources.ViewModels;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using Unity;

    /// <summary>
    /// Interaction logic for StartupView.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class StartupView : Window
    {
        private StartupViewModel _startupViewModel;
        public StartupView()
        {
            InitializeComponent();

            DataContext = ITUnityContainer.Instance.Resolve<StartupViewModel>();

            _startupViewModel = (StartupViewModel)DataContext;
            _startupViewModel.OpenWindowEventHandler += OnWindowOpen;
            Closed += OnWindowClose;
        }

        public void OnWindowClose(object sender, EventArgs e)
        {
            _startupViewModel.OpenWindowEventHandler -= OnWindowOpen;
        }

        public void OnWindowOpen(object sender, EventArgs e)
        {
            LanguageView languageTabView = new LanguageView();
            languageTabView.Show();
        }
    }
}
