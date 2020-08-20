namespace JoinIT.Resourses.Utilities
{
    using JoinIT.Resourses.LocalDataStore;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;
    class ComboboxTemplateSelector : DataTemplateSelector
    {
        #region Methods
        public string GetProperTemplateName(string keyProperty)
        {
            switch (keyProperty)
            {
                case "Id":
                    return StaticPropertiesStore.IdTemplate;
                case "CourseName":
                    return StaticPropertiesStore.NamesTemplate;
                case "AuthorName":
                    return StaticPropertiesStore.NamesTemplate;
                case "StartDate":
                    return StaticPropertiesStore.DatesTemplate;
                case "EndDate":
                    return StaticPropertiesStore.DatesTemplate;
            }

            return null;
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement frameworkElement = container as FrameworkElement;
            var properties = typeof(CourseInfoModel).GetProperties();
            if(item is KeyValuePair<string, string>)
            {
                var itemData = (KeyValuePair<string, string>)item;

                foreach (var itemProperty in properties)
                {
                    if (itemData.Key == itemProperty.ToString().Split(' ')[1])
                    {
                        return frameworkElement.FindResource(GetProperTemplateName(itemProperty.ToString().Split(' ')[1])) as DataTemplate;
                    }
                }
            }

            return null;
        }
        #endregion
    }
}
