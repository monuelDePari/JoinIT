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
        private readonly StartupViewModel _startupViewModel;
        public StartupView()
        {
            InitializeComponent();

            DataContext = ITUnityContainer.Instance.Resolve<StartupViewModel>();

            _startupViewModel = (StartupViewModel)DataContext;
            Loaded += StartupView_Loaded;
            Closed += StartupView_Closed;
        }

        private void StartupView_Loaded(object sender, RoutedEventArgs e)
        {
            _startupViewModel.OpenLanguageWindowEventHandler += OnLanguageWindowOpen;
            _startupViewModel.OpenCoursesWindowEventHandler += OnCoursesWindowOpen;
        }

        public void StartupView_Closed(object sender, EventArgs e)
        {
            _startupViewModel.OpenLanguageWindowEventHandler -= OnLanguageWindowOpen;
            _startupViewModel.OpenCoursesWindowEventHandler -= OnCoursesWindowOpen;
        }

        public void OnLanguageWindowOpen(object sender, EventArgs e)
        {
            LanguageView languageView = new LanguageView();
            languageView.Show();
        }

        public void OnCoursesWindowOpen(object sender, EventArgs e)
        {
            CoursesView coursesView = new CoursesView();
            coursesView.ShowDialog();
        }
    }
}
