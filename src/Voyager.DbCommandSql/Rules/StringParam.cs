using System;
using System.Data;

namespace Voyager.DbCommandSql.Rules
{
	internal class StringParam : ParamRule
	{
		public override string GetType(DbType dbType)
		{
			return "nvarchar";
		}

		public override string GetValue(object dbValue)
		{
			if (dbValue != null || dbValue != DBNull.Value)
				return $"N'{dbValue}'";
			return base.GetValue(dbValue);
		}

	}
}
