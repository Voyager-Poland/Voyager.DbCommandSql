using System.Data;
using System.Data.Common;

namespace Voyager.DbCommandSql.Rules
{
	internal class Int16Param : Int32Param
	{
		public override string GetType(DbType dbType)
		{
			return "small";
		}
		public override string GetTypeSize(DbParameter dbParam)
		{
			return string.Empty;
		}
	}
}
