namespace JoinIT.Resources.Views
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;

    /// <summary>
    /// Interaction logic for StartupView.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class StartupView
    {
        public StartupView()
        {
            InitializeComponent();
        }

        protected override void OnLoaded(object sender, RoutedEventArgs e)
        {
            base.OnLoaded(sender, e);

            ViewModel.OpenLanguageWindowEventHandler += OnLanguageWindowOpen;
            ViewModel.OpenCoursesWindowEventHandler += OnCoursesWindowOpen;
        }

        protected override void OnUnloaded(object sender, RoutedEventArgs e)
        {
            base.OnUnloaded(sender, e);

            ViewModel.OpenLanguageWindowEventHandler -= OnLanguageWindowOpen;
            ViewModel.OpenCoursesWindowEventHandler -= OnCoursesWindowOpen;
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
