namespace JoinIT.Resources.Views
{
    using Utilities;
    using ViewModels;
    using Models;
    using System.Diagnostics.CodeAnalysis;
    using Unity;
    using Unity.Resolution;

    /// <summary>
    /// Interaction logic for CoursesView.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class CoursesView
    {
        public CoursesView(CourseInfoModel courseInfoModel = null)
        {
            InitializeComponent();

            DataContext = ITUnityContainer.Instance.Resolve<ManageCoursesViewModel>(
                new ResolverOverride[] { new ParameterOverride(courseInfoModel.GetConstructorParameterName(typeof(ManageCoursesViewModel), 0, 1), courseInfoModel)});
        }
    }
}
