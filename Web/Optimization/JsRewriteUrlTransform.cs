using System;
using System.Web;
using System.Web.Optimization;

namespace TimeshEAT.Web.Optimization
{
	/// <summary>
	/// Rewrites urls to be absolute so assets will still be found after bundling
	/// </summary>
	public class JsRewriteUrlTransform : IItemTransform
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public JsRewriteUrlTransform()
		{
		}

		/// <summary>
		/// Converts any urls in the input to absolute using the base directory of the include virtual path.
		/// </summary>
		/// <param name="includedVirtualPath">The virtual path that was included in the bundle for this item that is being transformed</param>
		/// <param name="input"></param>
		/// <example>
		/// bundle.Include("~/js/global.js") will transform ~/path => domain_uri/path
		/// </example>
		public string Process(string includedVirtualPath, string input) =>
			input.Replace("~/", HttpContext.Current.Request.Url
				.GetLeftPart(UriPartial.Authority) + "/");
	}
}