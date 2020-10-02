namespace JoinIT.Resources.Utilities.TemplateSelectors
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using ITLocalData;
    using Extensions;
    using Models;

    [ExcludeFromCodeCoverage]
    public class ComboboxTemplateSelector : DataTemplateSelector
    {
        #region Methods
        public string GetProperTemplateName(string keyProperty)
        {
            var coursesPropertiesToCompare = typeof(CourseInfoModel).GetProperties();
            CourseInfoModel courseInfoModel = new CourseInfoModel();

            foreach (PropertyInfo propertyInfo in coursesPropertiesToCompare)
            {
                if (keyProperty == propertyInfo.Name && (keyProperty == courseInfoModel.GetPropertyName(t => t.CourseName) || keyProperty == courseInfoModel.GetPropertyName(t => t.AuthorName)))
                {
                    return ITConstants.NamesTemplate;
                }

                if (keyProperty == propertyInfo.Name && (keyProperty == courseInfoModel.GetPropertyName(t => t.StartDate) || keyProperty == courseInfoModel.GetPropertyName(t => t.EndDate)))
                {
                    return ITConstants.DatesTemplate;
                }
            }

            return null;
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement frameworkElement = container as FrameworkElement;
            var properties = typeof(CourseInfoModel).GetProperties();

            if (item is KeyValuePair<string, string>)
            {
                var itemData = (KeyValuePair<string, string>)item;

                foreach (var itemProperty in properties)
                {
                    if (itemData.Key == itemProperty.Name)
                    {
                        string propertyName = GetProperTemplateName(itemProperty.Name);
                        if (propertyName != null)
                        {
                            return frameworkElement.FindResource(propertyName) as DataTemplate;
                        }
                    }
                }
            }

            return null;
        }
        #endregion
    }
}
