using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using TimeshEAT.Web.Interfaces;

namespace TimeshEAT.Web.Extensions
{
    /// <summary>
    /// Extensions over models which represent form and inherit IForm interface
    /// </summary>
	public static class IFormExtensions
	{
		public static string DisplayName<T>(this T objModel, Expression<Func<T, object>> propLambda) where T : IForm =>
			(propLambda.Body as MemberExpression)?.Member?
				.GetCustomAttribute<DisplayAttribute>()?.Name?
					.Replace(":","");
	}
}