using Voyager.DbCommandSql;

namespace System.Data.Common
{
	public static class DbCommandSqlExt
	{
		public static string GetGeneratedQuery(this DbCommand dbCommand)
		{
			SqlGenerator sqlGenerator = (dbCommand.CommandType == CommandType.StoredProcedure) ? new StoredProcedureSql(dbCommand) : new QueryCommandSql(dbCommand);
			return sqlGenerator.Sql();
		}
	}
}
