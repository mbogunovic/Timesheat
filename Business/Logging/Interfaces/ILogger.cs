using System;

namespace TimeshEAT.Business.Logging.Interfaces
{
	public interface ILogger : IDisposable
	{
		void WriteInfoLog(string info);
		void WriteInfoLog(string info, object obj);
		void WriteWarningLog(string warning);
		void WriteWarningLog(string warning, object obj);
		void WriteErrorLog(string error, Exception ex);
		void WriteErrorLog(string error, object obj, Exception ex);
	}
}
