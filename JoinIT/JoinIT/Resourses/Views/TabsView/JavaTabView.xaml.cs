using JoinIT.Resourses.Enums;
using JoinIT.Resourses.Utilities;
using JoinIT.Resourses.ViewModels.Tabs;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
                await javaTabViewModel.LoadDataAsync(CourceNames.Java.ToString());
            }
        }
    }
}
