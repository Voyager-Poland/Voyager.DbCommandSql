using System.Data;

namespace Voyager.DbCommandSql.Rules
{

	internal class BoolParam : ParamRule
	{
		public BoolParam() : base(new TypeSizeEmpty()) { }

		public override string GetType(DbType dbType)
		{
			return "bit";
		}

	}

}
