using System.Data;
using System.Data.Common;

namespace Voyager.DbCommandSql.Rules
{
	internal class Int32Param : ParamRule
	{
		public override string GetType(DbType dbType)
		{
			return "int";
		}

		public override string GetTypeSize(DbParameter dbParam)
		{
			return string.Empty;
		}
	}

}
