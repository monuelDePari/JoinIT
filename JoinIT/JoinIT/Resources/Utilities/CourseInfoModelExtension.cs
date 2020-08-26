namespace JoinIT.Resources.Utilities
{
    using Models;
    using System;
    using System.Linq.Expressions;


    public static class CourseInfoModelExtension
    {
        private static string GetMemberName<T>(Expression<Func<T>> expression)
        {
            var info = expression.Body as MemberExpression;

            if(info == null)
            {
                return null;
            }

            return info.Member.Name;
        }
        public static string GetPropertyName<T>(this CourseInfoModel caller, Expression<Func<T>> propertyLambda)
        {
            return GetMemberName(propertyLambda);
        }
    }
}
