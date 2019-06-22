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
				.Include("~/js/global.min.js", new JsRewriteUrlTransform());
			bundles.Add(script);

			//TODO: MAKE CONFIGURABLE
			BundleTable.EnableOptimizations = true;
		}
	}
}