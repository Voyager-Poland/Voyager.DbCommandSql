using System;
using System.Data;
using System.Data.Common;

namespace Voyager.DbCommandSql.Rules
{

	internal abstract class ParamRule
	{
		public virtual string GetType(DbType type)
		{
			return type.ToString().ToLower();
		}

		public virtual string GetValue(object dbValue)
		{
			if (dbValue == null || dbValue == DBNull.Value)
				return "NULL";
			else
				return dbValue.ToString();
		}

		public virtual string GetTypeSize(DbParameter dbParam)
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
