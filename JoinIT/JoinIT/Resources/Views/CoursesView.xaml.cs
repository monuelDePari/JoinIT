namespace JoinIT.Resources.Views
{
    using Utilities;
    using ViewModels;
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

            DataContext = ITUnityContainer.Instance.Resolve<ManageCoursesViewModel>(
                new ResolverOverride[] { new ParameterOverride(courseInfoModel.GetConstructorParameterName(typeof(ManageCoursesViewModel), 0, 2), courseInfoModel)});
        }
    }
}
