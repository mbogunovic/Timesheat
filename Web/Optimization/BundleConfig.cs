using System.Web.Optimization;

namespace TimeshEAT.Web.Optimization
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			var style = new StyleBundle("~/styles/default")
				.Include("~/css/style.min.css", new CssRewriteUrlTransform());
			bundles.Add(style);

			var script = new ScriptBundle("~/scripts/default")
				.Include("~/js/global.min.js", new JsRewriteUrlTransform())
				.Include("~/js/table-search.js")
                .Include("~/js/common.js")
                .Include("~/js/companies.js")
                .Include("~/js/meals.js")
				.Include("~/js/orders.js");

			bundles.Add(script);

			//TODO: MAKE CONFIGURABLE
			BundleTable.EnableOptimizations = true;
		}
	}
}