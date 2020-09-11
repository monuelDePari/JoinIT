namespace JoinIT.Resources.Utilities
{
    using System;
    using System.IO;
    using System.Linq.Expressions;
    using System.Runtime.Serialization.Formatters.Binary;

    public static class CourseInfoModelExtension
    {
        public static string GetPropertyName<T, T1>(this T caller, Expression<Func<T, T1>> propertyLambda)
        {
            var info = propertyLambda.Body as MemberExpression;
            return info == null ? null : info.Member.Name;
        }
    }
}
