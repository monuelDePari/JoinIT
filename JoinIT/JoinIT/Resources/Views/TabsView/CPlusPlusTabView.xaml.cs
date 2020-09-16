namespace JoinIT.Resources.Views.TabsView
{
    using JoinIT.Resources.Enums;
    using JoinIT.Resources.Utilities;
    using JoinIT.Resources.ViewModels.TabsViewModels;
    using Models;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using Unity;

    /// <summary>
    /// Interaction logic for CPlusPlusTabView.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class CPlusPlusTabView
    {
        private readonly CPlusPlusTabViewModel _cPlusPlusTabViewModel;
        public CPlusPlusTabView()
        {
            InitializeComponent();

            DataContext = ITUnityContainer.Instance.Resolve<CPlusPlusTabViewModel>();

            _cPlusPlusTabViewModel = (CPlusPlusTabViewModel)DataContext;

            Loaded += CPlusPlusTab_Loaded;
            Unloaded += CPlusPlusTab_Unloaded;
        }

        private async void CPlusPlusTab_Loaded(object sender, RoutedEventArgs e)
        {
            var cPlusPlusViewModel = (CPlusPlusTabViewModel)DataContext;
            await cPlusPlusViewModel.LoadDataAsync(CourseNames.CPlusPlus.ToString());

            _cPlusPlusTabViewModel.UpdateCourseHandler += CPlusPlusCourseUpdate;
            
        }

        private void CPlusPlusTab_Unloaded(object sender, RoutedEventArgs e)
        {
            _cPlusPlusTabViewModel.UpdateCourseHandler -= CPlusPlusCourseUpdate;
        }

        private void CPlusPlusCourseUpdate(object sender, EventArgs e)
        {
            CoursesView coursesView = new CoursesView((CourseInfoModel)sender);
            coursesView.ShowDialog();
        }
    }
}
