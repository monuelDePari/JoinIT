﻿namespace JoinIT.Resources.ViewModels
{
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Windows;
    using Prism.Events;
    using Utilities;
    using System;
    using Utilities.Commands;
    using Utilities.Commands.Instructions;
    using Utilities.Extensions;
    using Utilities.Wrappers;

    public class StartupViewModel : ITBaseViewModel
    {
        #region Fields

        private Dictionary<int, string> _fontSizeDictionary;
        private int _selectedFontSize;
        private RelativeCommand _openLanguageWindowCommand;
        private RelativeCommand _openCoursesWindowCommand;
        private RelativeCommand _deleteFromDataGrid;

        private IApplicationCommands _applicationCommands;
        private readonly IEventAggregator _deleteFromUserControlDataGridEventAggregator;
        private readonly IITApplication _application;

        #endregion

        #region Constructors

        public StartupViewModel(IApplicationCommands applicationCommands, IEventAggregator eventAggregator, IITApplication application)
        {
            FontSizeDictionary = new Dictionary<int, string>
            {
                { 5, "5 pt" },
                { 6, "6 pt" },
                { 7, "7 pt" },
                { 8, "8 pt" },
                { 9, "9 pt" },
                { 12, "12 pt" },
                { 14, "14 pt" },
                { 16, "16 pt" },
                { 18, "18 pt" },
                { 20, "20 pt" },
                { 22, "22 pt" },
                { 24, "24 pt" }
            };

            ApplicationCommands = applicationCommands;
            OpenLanguageWindowCommand = new RelativeCommand(OnOpenLanguageWindow, OpenLanguageWindowCommand_CanExecute);
            OpenCoursesWindowCommand = new RelativeCommand(OnOpenCoursesWindow, OpenCoursesWindowCommand_CanExecute);
            DeleteFromDataGrid = new RelativeCommand(OnDeleteCourses);

            _deleteFromUserControlDataGridEventAggregator = eventAggregator;
            _application = application;
        }

        #endregion

        #region Methods

        public override void OnCustomPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == this.GetPropertyName(t => SelectedFontSize) && SelectedFontSize != _application.FontSize)
            {
                _application.FontSize = SelectedFontSize;
            }
        }

        private void OnDeleteCourses(object obj)
        {
            _deleteFromUserControlDataGridEventAggregator.GetEvent<DeleteItemFromUserControlDataGridEvent>().Publish();
        }

        private void OnOpenLanguageWindow(object sender)
        {
            var handler = OpenLanguageWindowEventHandler;
            if (handler != null)
            {
                handler(null, EventArgs.Empty);
            }
        }

        private void OnOpenCoursesWindow(object sender)
        {
            var handler = OpenCoursesWindowEventHandler;
            if (handler != null)
            {
                handler(null, EventArgs.Empty);
            }
        }

        public bool OpenCoursesWindowCommand_CanExecute()
        {
            return OpenCoursesWindowEventHandler != null && !IsLoading;
        }

        public bool OpenLanguageWindowCommand_CanExecute()
        {
            return OpenLanguageWindowEventHandler != null && !IsLoading;
        }
        #endregion

        #region AttachedProperties

        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.RegisterAttached("Content", typeof(object),
                typeof(StartupViewModel), new PropertyMetadata());


        public static object GetContent(DependencyObject obj)
        {
            return obj.GetValue(ContentProperty);
        }

        public static void SetContent(DependencyObject obj, object value)
        {
            obj.SetValue(ContentProperty, value);
        }

        #endregion

        #region Commands

        public IApplicationCommands ApplicationCommands
        {
            get
            {
                return _applicationCommands;
            }
            set
            {
                _applicationCommands = value;
                OnPropertyChanged();
            }
        }

        public RelativeCommand OpenLanguageWindowCommand
        {
            get
            {
                return _openLanguageWindowCommand;
            }
            set
            {
                _openLanguageWindowCommand = value;
                OnPropertyChanged();
            }
        }

        public RelativeCommand OpenCoursesWindowCommand
        {
            get
            {
                return _openCoursesWindowCommand;
            }
            set
            {
                _openCoursesWindowCommand = value;
                OnPropertyChanged();
            }
        }

        public RelativeCommand DeleteFromDataGrid
        {
            get
            {
                return _deleteFromDataGrid;
            }
            set
            {
                _deleteFromDataGrid = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Properties

        public int SelectedFontSize
        {
            get
            {
                return _selectedFontSize;
            }
            set
            {
                _selectedFontSize = value;
                OnPropertyChanged();
            }
        }

        public Dictionary<int, string> FontSizeDictionary
        {
            get
            {
                return _fontSizeDictionary;
            }
            set
            {
                _fontSizeDictionary = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Events

        public event EventHandler OpenLanguageWindowEventHandler;
        public event EventHandler OpenCoursesWindowEventHandler;

        #endregion
    }
}
