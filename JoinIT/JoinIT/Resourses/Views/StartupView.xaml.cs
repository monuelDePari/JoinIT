﻿namespace JoinIT.Resourses.Views
{
    using JoinIT.Resourses.ViewModels;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;

    /// <summary>
    /// Interaction logic for Startup.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class Startup : Window
    {
        public Startup()
        {
            InitializeComponent();

            DataContext = new StartupViewModel();
        }
    }
}