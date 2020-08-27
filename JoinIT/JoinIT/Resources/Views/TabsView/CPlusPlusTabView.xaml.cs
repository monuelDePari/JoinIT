using JoinIT.Resources.Enums;
using JoinIT.Resources.Utilities;
using JoinIT.Resources.ViewModels.TabsViewModels;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using Unity;

namespace JoinIT.Resources.Views.TabsView
{
    /// <summary>
    /// Interaction logic for CPlusPlusTabView.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class CPlusPlusTabView
    {
        public CPlusPlusTabView()
        {
            InitializeComponent();

            DataContext = ITUnityContainer.Instance.Resolve<CPlusPlusTabViewModel>();

            Loaded += CPlusPlusTab_Loaded;
        }

        private async void CPlusPlusTab_Loaded(object sender, RoutedEventArgs e)
        {
            var cPlusPlusViewModel = (CPlusPlusTabViewModel)DataContext;
            await cPlusPlusViewModel.LoadDataAsync(CourseNames.CPlusPlus.ToString());
        }
    }
}
