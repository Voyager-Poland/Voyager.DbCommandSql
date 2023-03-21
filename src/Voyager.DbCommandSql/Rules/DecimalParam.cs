using System.Globalization;

namespace Voyager.DbCommandSql.Rules
{
	internal class DecimalParam : ParamRule
	{
		public override string GetValue(object dbValue)
		{
			if (dbValue != null && dbValue != DBNull.Value)
				return $"{((decimal)dbValue).ToString("0.####", CultureInfo.InvariantCulture)}";

			return base.GetValue(dbValue);
		}
	}
}
