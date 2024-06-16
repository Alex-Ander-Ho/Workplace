using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Workplace.Client.Utils
{
    public static class Utilities
    {
        public static string DisplayName<T>(Expression<Func<T>> expr)
        {
            var name = ((MemberExpression)expr.Body).Member
                .CustomAttributes.First(x => x.AttributeType == typeof(DisplayAttribute))
                .NamedArguments.First(x => x.MemberName == "Name").TypedValue.Value;
            return (string)name!;
        }
    }
}
