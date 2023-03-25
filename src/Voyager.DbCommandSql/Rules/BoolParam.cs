using System.Data;
using System.Data.Common;

namespace Voyager.DbCommandSql.Rules
{

	internal class BoolParam : ParamRule
	{
		public override string GetType(DbType dbType)
		{
			return "bit";
		}

		public override string GetTypeSize(DbParameter dbParam)
		{
			return string.Empty;
		}
	}

}
