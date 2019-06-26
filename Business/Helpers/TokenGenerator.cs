using System;

namespace TimeshEAT.Business.Helpers
{
	public static class TokenGenerator
	{
		public static string GenerateToken() =>
			StringHasher.GenerateHash(DateTime.Now.Ticks.ToString());
	}
}
