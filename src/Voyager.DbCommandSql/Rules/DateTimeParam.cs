using System;
using System.Data.Common;

namespace Voyager.DbCommandSql.Rules
{
	internal class DateTimeParam : ParamRule
	{
		public override string GetValue(object dbValue)
		{
			if (dbValue != null && dbValue != DBNull.Value)
				return $"'{(DateTime)dbValue:yyyy-MM-dd HH:mm:ss.fff}'";
			return base.GetValue(dbValue);
		}

		public override string GetTypeSize(DbParameter dbParam)
		{
			return string.Empty;
		}
	}
}
