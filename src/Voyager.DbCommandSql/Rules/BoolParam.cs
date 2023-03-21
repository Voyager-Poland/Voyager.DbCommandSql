using System.Data;

namespace Voyager.DbCommandSql.Rules
{

	internal class BoolParam : ParamRule
	{
		public override string GetType(DbType dbType)
		{
			return "bit";
		}
	}

}
