﻿namespace JoinIT.Resources.Views.Controls
{
    using Utilities;
    using ViewModels;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;
    using Unity;

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