using JoinIT.Resourses.Enums;
using JoinIT.Resourses.Utilities;
using JoinIT.Resourses.ViewModels.TabsViewModels;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using Unity;

namespace JoinIT.Resourses.Views.TabsView
{
    /// <summary>
    /// Interaction logic for JavaTabView.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class JavaTabView : UserControl
    {
        public JavaTabView()
        {
            InitializeComponent();

            ITUnityContainer.GetInstance.Resolve<JavaTabViewModel>();

            Loaded += JavaTab_Loaded;
        }

        private async void JavaTab_Loaded(object sender, RoutedEventArgs e)
        {
            var javaTabViewModel = DataContext as CSharpTabViewModel;
            if (javaTabViewModel != null)
            {
                await javaTabViewModel.LoadDataAsync(CourseNames.Java.ToString());
            }
        }
    }
}
