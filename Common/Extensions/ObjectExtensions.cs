using System.Collections.Generic;
using System.Linq;

namespace TimeshEAT.Common.Extensions
{
	/// <summary>
	/// Extensions over object
	/// </summary>
	public static class ObjectExtensions
	{
		/// <summary>
		/// Checks if object isn't null and does it have some value (elements if IEnumerable)
		/// </summary>
		/// <param name="source">The source (object).</param>
		/// <returns>boolean true/false</returns>
		public static bool HasValue(this object obj) =>
			(obj as IEnumerable<object>)?.Any() ?? obj != null && !string.IsNullOrWhiteSpace(obj.ToString());
	}
}
