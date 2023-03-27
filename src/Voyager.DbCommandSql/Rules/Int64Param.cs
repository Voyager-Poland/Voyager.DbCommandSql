using System.Data;

namespace Voyager.DbCommandSql.Rules
{

	internal class Int64Param : Int32Param
	{
		public override string GetType(DbType dbType)
		{
			return "bigint";
		}


	}

}
