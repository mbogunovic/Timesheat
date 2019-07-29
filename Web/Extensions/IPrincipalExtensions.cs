using System.Security.Principal;
using TimeshEAT.Web.Membership;

namespace TimeshEAT.Web.Extensions
{
    /// <summary>
    /// Extensions over custom membership principal which inherits IPrincipal interface
    /// </summary>
    public static class IPrincipalExtensions
    {
        public static string GetFullName(this IPrincipal principal) =>
            ((MemberPrincipal)principal).FullName;
    }
}