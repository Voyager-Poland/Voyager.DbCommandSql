using System;
using System.Data;

namespace Voyager.DbCommandSql.Rules
{

	internal abstract class ParamRule
	{
		public virtual string GetType(DbType dbType)
		{
			return dbType.ToString().ToLower();
		}

		public virtual string GetValue(object dbValue)
		{
			if (dbValue == null || dbValue == DBNull.Value)
				return "NULL";
			else
				return dbValue.ToString();
		}
	}

}
