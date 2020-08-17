namespace JoinIT.Resourses.Views
{
    using JoinIT.Resourses.ViewModels;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;

    /// <summary>
    /// Interaction logic for StartupView.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class StartupView : Window
    {
        public StartupView()
        {
            InitializeComponent();

            DataContext = new StartupViewModel();
        }
    }
}
