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

			var def = new ScriptBundle("~/scripts/default")
				.Include("~/js/global.min.js", new JsRewriteUrlTransform())
				.Include("~/js/table-search.js")
				.Include("~/js/common.js")
				.Include("~/js/companies.js")
				.Include("~/js/meals.js")
				.Include("~/js/orders.js")
				.Include("~/js/forms.js");

			bundles.Add(def);

			var forms = new ScriptBundle("~/scripts/forms")
				.Include("~/Scripts/jquery.validate.min.js")
				.Include("~/Scripts/jquery.validate.unobtrusive.min.js")
				.Include("~/Scripts/jquery.unobtrusive-ajax.min.js");

			bundles.Add(forms);

			//TODO: MAKE CONFIGURABLE
			BundleTable.EnableOptimizations = true;
		}
	}
}