using System.Data;

namespace Voyager.DbCommandSql.Rules
{
	internal class ByteParam : Int32Param
	{
		public override string GetType(DbType dbType)
		{
			return "tinyint";
		}
	}
}
