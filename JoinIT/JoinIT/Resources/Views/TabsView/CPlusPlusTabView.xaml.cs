using JoinIT.Resources.Enums;

namespace JoinIT.Resources.Views.TabsView
{
    using Controls;
    using ViewModels.TabsViewModels;
    using Models;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;

    /// <summary>
    /// Interaction logic for CPlusPlusTabView.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class CPlusPlusTabView
    {
        public CPlusPlusTabView()
        {
            InitializeComponent();
        }

        protected override void OnLoaded(object sender, RoutedEventArgs e)
        {
            base.OnLoaded(sender, e);

            ViewModel.UpdateCourseHandler += CSharpCourseUpdate;
        }

        protected override void OnUnloaded(object sender, RoutedEventArgs e)
        {
            base.OnUnloaded(sender, e);

            ViewModel.UpdateCourseHandler -= CSharpCourseUpdate;
        }

        private void CSharpCourseUpdate(object sender, EventArgs e)
        {
            CoursesView coursesView = new CoursesView((CourseInfoModel)sender);
            coursesView.ShowDialog();
        }
    }
}
