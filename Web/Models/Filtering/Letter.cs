namespace TimeshEAT.Web.Models.Filtering
{
	public class Letter
	{
		public Letter(string value)
		{
			Value = value;
		}

		public string Value { get; set; }
		public bool IsActive { get; set; }
		public bool IsAvailable { get; set; }
	}
}