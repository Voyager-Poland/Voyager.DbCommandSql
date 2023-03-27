using System;
using System.Data;

namespace Voyager.DbCommandSql.Rules
{

	internal class AnsiStringParam : StringParam
	{


		public override string GetType(DbType dbType)
		{
			return "varchar";
		}

		public override string GetValue(object dbValue)
		{
			if (dbValue != null && dbValue != DBNull.Value)
				return $"'{dbValue}'";
			return base.GetValue(dbValue);
		}
	}

}
