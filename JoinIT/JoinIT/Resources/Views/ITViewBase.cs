namespace JoinIT.Resources.Views
{
    using Utilities;
    using Unity;
    using System.Windows;
    using ViewModels;

    public class ITViewBase<TViewModel> : Window where TViewModel : ITBaseViewModel
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel", typeof(TViewModel), typeof(ITViewBase<TViewModel>),
            new PropertyMetadata(default(TViewModel)));

        public TViewModel ViewModel
        {
            get { return (TViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public ITViewBase()
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
