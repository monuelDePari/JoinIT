namespace JoinIT.Resources.Utilities
{
    using System.Diagnostics.CodeAnalysis;
    using Models;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using JoinIT.Resources.ITConstants;
    using System.Text.RegularExpressions;
    using System.Reflection;
    using System.Linq.Expressions;
    using System;

    [ExcludeFromCodeCoverage]
    public class ComboboxTemplateSelector : DataTemplateSelector
    {
        #region Methods
        public string GetPropertyName<T>(Expression<Func<T>> propertyLambda)
        {
            var info = propertyLambda.Body as MemberExpression;

            if (info == null)
            {
                return null;
            }

            return info.Member.Name;
        }

        public string GetProperTemplateName(string keyProperty)
        {
            var coursesPropertiesToCompare = typeof(CourseInfoModel).GetProperties();
            CourseInfoModel courseInfoModel = new CourseInfoModel();

            for (int i = 0; i < coursesPropertiesToCompare.Length; i++)
            {
                if (keyProperty == coursesPropertiesToCompare[i].Name && keyProperty == GetPropertyName(() => courseInfoModel.Id))
                {
                    return ITConstants.IdTemplate;
                }
                else if (keyProperty == coursesPropertiesToCompare[i].Name && (keyProperty == GetPropertyName(() => courseInfoModel.CourseName) || keyProperty == GetPropertyName(() => courseInfoModel.AuthorName)))
                {
                    return ITConstants.NamesTemplate;
                }
                else if(keyProperty == coursesPropertiesToCompare[i].Name && (keyProperty == GetPropertyName(() => courseInfoModel.StartDate) || keyProperty == GetPropertyName(() => courseInfoModel.EndDate)))
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
                        return frameworkElement.FindResource(GetProperTemplateName(itemProperty.Name)) as DataTemplate;
                    }
                }
            }

            return null;
        }
        #endregion
    }
}
