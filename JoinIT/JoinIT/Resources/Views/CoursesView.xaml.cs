namespace JoinIT.Resources.Views
{
    using JoinIT.Resources.Utilities;
    using JoinIT.Resources.ViewModels.TabsViewModels;
    using Models;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using Unity;
    using Unity.Injection;

    /// <summary>
    /// Interaction logic for CoursesView.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class CoursesView : Window
    {
        public CoursesView()
        {
            InitializeComponent();

            DataContext = ITUnityContainer.Instance.Resolve<CoursesTabViewModel>();
        }

        public CoursesView(CourseInfoModel courseInfoModel)
        {
            InitializeComponent();

            ITUnityContainer.Instance.RegisterType<CourseInfoModel>(new InjectionFactory(t => courseInfoModel));

            DataContext = ITUnityContainer.Instance.Resolve<CoursesTabViewModel>();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
