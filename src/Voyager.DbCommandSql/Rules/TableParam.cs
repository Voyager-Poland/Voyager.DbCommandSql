using System.Data;

namespace Voyager.DbCommandSql.Rules
{
	internal class TableParam : ParamRule
	{
		public override string GetValue(object dbValue)
		{
			if (dbValue != null || dbValue != DBNull.Value)
			{

				DataTable dataTable = dbValue as DataTable;
				if (dataTable != null)
				{
					string text = string.Empty;
					for (int r = 0; r < dataTable.Rows.Count; r++)
					{
						for (int c = 0; c < dataTable.Columns.Count; c++)
						{
							object v = dataTable.Rows[r][c];
							text += (v != null ? v.ToString() : string.Empty) + ";";
						}
						text += "|";
					}
					return text;
				}
			}
			return base.GetValue(dbValue);
		}
	}
}
