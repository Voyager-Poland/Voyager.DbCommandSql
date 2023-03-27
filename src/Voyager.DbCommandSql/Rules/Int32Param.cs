using System.Data;

namespace Voyager.DbCommandSql.Rules
{
	internal class Int32Param : ParamRule
	{
		public Int32Param() : base(new TypeSizeEmpty())
		{ }

		public override string GetType(DbType dbType)
		{
			return "int";
		}

	}

}
