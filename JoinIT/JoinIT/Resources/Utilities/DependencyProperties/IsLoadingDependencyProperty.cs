namespace JoinIT.Resources.Utilities.DependencyProperties
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;

    [ExcludeFromCodeCoverage]
    public class IsLoadingDependencyProperty : DependencyObject
    {
        public static readonly DependencyProperty IsLoadingProperty = DependencyProperty.RegisterAttached("IsLoading", typeof(bool), typeof(IsLoadingDependencyProperty), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Inherits));

        public bool IsLoading
        {
            get
            {
                return (bool)GetValue(IsLoadingProperty);
            }
            set
            {
                SetValue(IsLoadingProperty, value);
            }
        }
    }
}
