namespace JoinIT.Resources.Views.TabsView
{
    using Models;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;

    /// <summary>
    /// Interaction logic for JavaTabView.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class JavaTabView
    {
        public JavaTabView()
        {
            InitializeComponent();
        }

        protected override void OnLoaded(object sender, RoutedEventArgs e)
        {
            base.OnLoaded(sender, e);

            ViewModel.UpdateCourseHandler += JavaCourseUpdate;
        }

        protected override void OnUnloaded(object sender, RoutedEventArgs e)
        {
            base.OnUnloaded(sender, e);

            ViewModel.UpdateCourseHandler -= JavaCourseUpdate;
        }

        private void JavaCourseUpdate(object sender, EventArgs e)
        {
            CoursesView coursesView = new CoursesView((CourseInfoModel)sender);
            coursesView.ShowDialog();
        }
    }
}
