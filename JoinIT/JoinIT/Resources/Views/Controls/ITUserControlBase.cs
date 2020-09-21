using JoinIT.Resources.Utilities;
using JoinIT.Resources.ViewModels;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using JoinIT.Resources.Enums;
using JoinIT.Resources.ViewModels.TabsViewModels;
using Unity;
using Unity.Resolution;

namespace JoinIT.Resources.Views.Controls
{
    [ExcludeFromCodeCoverage]
    public class ITUserControlBase<TViewModel> : UserControl where TViewModel : ITBaseViewModel
    {

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel", typeof(TViewModel), typeof(ITUserControlBase<TViewModel>),
            new PropertyMetadata(default(TViewModel)));

        public TViewModel ViewModel
        {
            get { return (TViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public ITUserControlBase()
        {
            ViewModel = ITUnityContainer.Instance.Resolve<TViewModel>();
            DataContext = ViewModel;
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }

        protected virtual void OnLoaded(object sender, RoutedEventArgs e)
        {
            ViewModel.OnLoaded();
        }

        protected virtual void OnUnloaded(object sender, RoutedEventArgs e)
        {
            ViewModel.OnUnloaded();
        }
    }
}