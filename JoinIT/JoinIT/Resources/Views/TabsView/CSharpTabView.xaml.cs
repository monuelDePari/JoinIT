namespace JoinIT.Resources.Views.TabsView
{
    using Models;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;

    /// <summary>
    /// Interaction logic for CSharpTabView.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class CSharpTabView
    { 
        public CSharpTabView()
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
