namespace JoinIT.Resources.Utilities
{
    using System;
    using System.Linq.Expressions;


    public class ClassInfo
    {
        public static string GetPropertyName<T>(Expression<Func<T>> propertyLambda)
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
