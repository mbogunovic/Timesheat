using SimpleInjector.Advanced;
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;

namespace TimeshEAT.Web.Injection
{
	public class ImportPropertySelectionBehavior : IPropertySelectionBehavior
	{
		public bool SelectProperty(Type implementationType, PropertyInfo prop) =>
			prop.GetCustomAttributes(typeof(ImportAttribute)).Any();
	}
}