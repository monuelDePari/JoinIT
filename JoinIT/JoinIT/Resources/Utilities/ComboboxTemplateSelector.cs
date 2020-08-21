namespace JoinIT.Resources.Utilities
{
    using System.Diagnostics.CodeAnalysis;
    using Models;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using JoinIT.Resources.ITConstants;
    using System.Text.RegularExpressions;

    [ExcludeFromCodeCoverage]
    public class ComboboxTemplateSelector : DataTemplateSelector
    {
        #region Methods
        public string GetProperTemplateName(string keyProperty)
        {
            ITConstants propertiesStore = new ITConstants();

            var coursesPropertiesToCompare = typeof(CourseInfoModel).GetProperties();

            for (int i = 0; i < coursesPropertiesToCompare.Length; i++)
            {
                if (keyProperty == coursesPropertiesToCompare[i].Name && propertiesStore.GetIdTemplate().Contains(Regex.Replace((keyProperty), "([a-z])([A-Z])", "$1 $2").Split(' ')[1]))
                {
                    return propertiesStore.GetIdTemplate();
                }
                else if (keyProperty == coursesPropertiesToCompare[i].Name && propertiesStore.GetNamesTemplate().Contains(Regex.Replace((keyProperty), "([a-z])([A-Z])", "$1 $2").Split(' ')[1]))
                {
                    return propertiesStore.GetNamesTemplate();
                }
                else if(keyProperty == coursesPropertiesToCompare[i].Name && propertiesStore.GetDatesTemplate().Contains(Regex.Replace((keyProperty), "([a-z])([A-Z])", "$1 $2").Split(' ')[1]))
                {
                    return propertiesStore.GetDatesTemplate();
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
                        return frameworkElement.FindResource(GetProperTemplateName(itemProperty.Name)) as DataTemplate;
                    }
                }
            }

            return null;
        }
        #endregion
    }
}
