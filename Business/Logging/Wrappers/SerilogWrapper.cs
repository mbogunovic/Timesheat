using Serilog;
using System;

namespace TimeshEAT.Business.Logging.Wrappers
{
	public class SerilogWrapper : Interfaces.ILogger
	{
		public SerilogWrapper(string path)
		{
			Log.Logger = new LoggerConfiguration()
				.WriteTo.RollingFile(path + "/log-{Date}.txt")
				.CreateLogger();
		}

		public void WriteInfoLog(string info) =>
			Log.Information(info);

		public void WriteInfoLog(string info, object obj) =>
			Log.Information(info + Environment.NewLine + "{@obj}", obj);

		public void WriteErrorLog(string error, object obj, Exception ex) =>
			Log.Error(error + Environment.NewLine + " {@obj}" + Environment.NewLine + "{err}", obj, ex);

		public void WriteWarningLog(string warning) =>
			Log.Warning(warning);

		public void WriteWarningLog(string warning, object obj) =>
			Log.Warning(warning + Environment.NewLine + "{@obj}", obj);

		public void Dispose() =>
			Log.CloseAndFlush();

		public void WriteErrorLog(string error, Exception ex) =>
			Log.Error(error + Environment.NewLine + " {err}", ex);
	}
}