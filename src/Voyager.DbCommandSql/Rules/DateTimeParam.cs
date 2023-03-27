using System;

namespace Voyager.DbCommandSql.Rules
{
	internal class DateTimeParam : ParamRule
	{

		public DateTimeParam() : base(new TypeSizeEmpty()) { }
		public override string GetValue(object dbValue)
		{
			if (dbValue != null && dbValue != DBNull.Value)
				return $"'{(DateTime)dbValue:yyyy-MM-dd HH:mm:ss.fff}'";
			return base.GetValue(dbValue);
		}

	}
}
