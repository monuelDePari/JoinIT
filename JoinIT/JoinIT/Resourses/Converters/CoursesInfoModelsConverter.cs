namespace JoinIT.Resourses.Converters
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public static class CoursesInfoModelsConverter
    {
        #region Methods
        public static string GetMemberName<T, TValue>(Expression<Func<T, TValue>> memberAccess)
        {
            return ((MemberExpression)memberAccess.Body).Member.Name;
        }
        public static Dictionary<string, string> CourseInfoModelsListToDictionary(List<CourseInfoModel> listToConvert)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            foreach (var item in listToConvert)
            {
                keyValuePairs.Add(GetMemberName((CourseInfoModel courseInfoModel) => courseInfoModel.CourseName), item.CourseName);
                keyValuePairs.Add(GetMemberName((CourseInfoModel courseInfoModel) => courseInfoModel.StartDate), item.StartDate.ToString());
            }
            return keyValuePairs;
        }
        #endregion
    }
}
