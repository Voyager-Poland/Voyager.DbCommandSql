using System.Data.Common;

namespace Voyager.DbCommandSql
{
	partial class StoredProcedureSql : SqlGenerator
	{

		public StoredProcedureSql(DbCommand dbCommand) : base(dbCommand) { }


		protected override string GetCallText(DbCommand dbCommand)
		{
			return "EXEC " + dbCommand.CommandText;
		}



		protected override string Parameters(DbCommand dbCommand)
		{
			string parametry = string.Empty;

			foreach (DbParameter dbpar in dbCommand.Parameters)
			{
				if (!string.IsNullOrEmpty(parametry))
					parametry += ",";

				if (OuptPutType(dbpar.Direction))
					parametry += $" {dbpar.ParameterName}={dbpar.ParameterName} OUTPUT";
				else
					parametry += $" {dbpar.ParameterName}={GetPrepareValue(dbpar)}";
			}
			return parametry;
		}



	}
}
