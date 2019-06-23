namespace TimeshEAT.Web.ViewModels
{
	public class ErrorViewModel
	{
		public ErrorViewModel() { }

		public ErrorViewModel(string code, string message)
		{
			Code = code;
			Message = message;
		}

		public string Code { get; set; }
		public string Message { get; set; }
	}
}