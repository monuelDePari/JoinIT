namespace JoinIT.Resources.Views
{
    using JoinIT.Resources.Utilities;
    using JoinIT.Resources.ViewModels;
    using Models;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using Unity;
    using Unity.Injection;
    using Unity.Resolution;

    /// <summary>
    /// Interaction logic for CoursesView.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class CoursesView : Window
    {
        public CoursesView(CourseInfoModel courseInfoModel = null)
        {
            InitializeComponent();

            DataContext = ITUnityContainer.Instance.Resolve<ManageCoursesViewModel>(new ResolverOverride[] { new ParameterOverride("courseModel", courseInfoModel)});
        }
    }
}
