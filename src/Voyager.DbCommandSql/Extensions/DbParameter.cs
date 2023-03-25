

namespace System.Data.Common
{
	internal static class DbParameterExt
	{

		public static string GetTypeSize(this DbParameter dbParam)
		{
			string result = string.Empty;
			if (dbParam.Size > 0)
				result += $"({dbParam.Size})";
			if (dbParam.Precision > 0)
				result += $"({dbParam.Precision},{dbParam.Scale})";
			return result;
		}
	}
}
