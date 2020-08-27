namespace JoinIT.Resources.Views
{
    using JoinIT.Resources.Utilities;
    using JoinIT.Resources.ViewModels.TabsViewModels;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Controls;
    using Unity;

    /// <summary>
    /// Interaction logic for CoursesView.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class CoursesView : UserControl
    {
        public CoursesView()
        {
            InitializeComponent();

            DataContext = ITUnityContainer.Instance.Resolve<CoursesTabViewModel>();
        }
    }
}
