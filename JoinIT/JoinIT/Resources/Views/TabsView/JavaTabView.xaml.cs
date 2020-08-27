using JoinIT.Resources.Enums;
using JoinIT.Resources.Utilities;
using JoinIT.Resources.ViewModels.TabsViewModels;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using Unity;

namespace JoinIT.Resources.Views.TabsView
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

            ITUnityContainer.Instance.Resolve<JavaTabViewModel>();

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
