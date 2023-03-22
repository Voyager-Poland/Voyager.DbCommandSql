using Voyager.DbCommandSql;

namespace System.Data.Common
{
	public static class DbCommandSqlExt
	{
		public static string GetSql(this DbCommand dbCommand)
		{
			if (dbCommand.CommandType == CommandType.StoredProcedure)
				return new StoredProcedureSql(dbCommand).GetSql();
			else
				return new QueryCommandSql(dbCommand).GetSql();
		}
	}
}
