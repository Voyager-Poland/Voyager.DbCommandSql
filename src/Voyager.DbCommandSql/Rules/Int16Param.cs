using System.Data;

namespace Voyager.DbCommandSql.Rules
{
	internal class Int16Param : Int32Param
	{
		public override string GetType(DbType dbType)
		{
			return "small";
		}
	}
}
