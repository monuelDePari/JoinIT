namespace JoinIT.Resourses.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    class ComboboxTemplateSelector : DataTemplateSelector
    {
        #region Methods
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement frameworkElement = container as FrameworkElement;
            if(frameworkElement != null && item != null && item is Dictionary<Type, string>)
            {
                var itemData = item as Dictionary<Type, string>;
                if (itemData.ContainsKey(typeof(string)))
                {
                    return frameworkElement.FindResource("CourseNamesTemplate") as DataTemplate;
                }else if (itemData.ContainsKey(typeof(DateTime)))
                {
                    return frameworkElement.FindResource("StartDatesTemplate") as DataTemplate;
                }
            }
            return null;
        }
        #endregion
    }
}
