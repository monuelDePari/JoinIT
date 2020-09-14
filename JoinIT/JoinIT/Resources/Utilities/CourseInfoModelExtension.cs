namespace JoinIT.Resources.Utilities
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Windows;

    public static class CourseInfoModelExtension
    {
        public static string GetPropertyName<T, T1>(this T caller, Expression<Func<T, T1>> propertyLambda)
        {
            var info = propertyLambda.Body as MemberExpression;
            return info == null ? null : info.Member.Name;
        }
        public static string GetConstructorParameterName<T>(this T caller, Type type, int constructorIndex, int parameterIndex)
        {
            if (constructorIndex >= 0 && parameterIndex >= 0)
            {
                try
                {
                    ConstructorInfo[] constructors = type.GetConstructors();
                    ConstructorInfo constructor = constructors[constructorIndex];
                    string result = constructor.GetParameters()[parameterIndex].Name;
                    return result;
                }
                catch(IndexOutOfRangeException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            return null;
        }
    }
}
