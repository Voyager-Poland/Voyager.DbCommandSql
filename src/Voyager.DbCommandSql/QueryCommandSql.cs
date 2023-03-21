using System.Data.Common;

namespace Voyager.DbCommandSql
{
	class QueryCommandSql : SqlGenerator
	{

		public QueryCommandSql(DbCommand dbCommand) : base(dbCommand) { }


		protected override string Parameters(DbCommand dbCommand)
		{
			string query = dbCommand.CommandText;
			foreach (DbParameter parameter in dbCommand.Parameters)
				if (!OuptPutType(parameter.Direction))
					query = query.Replace(parameter.ParameterName, GetPrepareValue(parameter));
			return query;
		}
		protected override string GetCallText(DbCommand dbCommand)
		{
			return string.Empty;
		}
	}
}
