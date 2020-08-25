namespace JoinIT.Resources.Utilities
{
    using System;
    using System.Linq.Expressions;


    public static class CourseInfoModelExtension
    {
        public static string GetPropertyName<T>(this Expression<Func<T>> propertyLambda)
        {
            var info = propertyLambda.Body as MemberExpression;

            if (info == null)
            {
                return null;
            }

            return info.Member.Name;
        }
    }
}
