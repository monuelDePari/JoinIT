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
    /// Interaction logic for CSharpTabView.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class CSharpTabView : UserControl
    {
        public CSharpTabView()
        {
            InitializeComponent();

            DataContext = ITUnityContainer.Instance.Resolve<CSharpTabViewModel>();

            Loaded += CSharpTab_Loaded;
        }

        private async void CSharpTab_Loaded(object sender, RoutedEventArgs e)
        {
            var cSharpTabViewModel = DataContext as CSharpTabViewModel;
            if (cSharpTabViewModel != null)
            {
                await cSharpTabViewModel.LoadDataAsync(CourseNames.CSharp.ToString());
            }
        }
    }
}
