using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;

namespace JoinIT.Resources.Views.Controls
{
    /// <summary>
    /// Interaction logic for SpinnerControl.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class SpinnerControl : UserControl
    {
        #region DependencyProperties
        public static readonly DependencyProperty IsLoadingProperty =  
            DependencyProperty.Register("IsLoading", typeof(bool), typeof(SpinnerControl));

        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set
            {
                SetValue(IsLoadingProperty, value);
            }
        }
        #endregion

        #region Constructors
        public SpinnerControl()
        {
            InitializeComponent();
        }
        #endregion
    }
}
