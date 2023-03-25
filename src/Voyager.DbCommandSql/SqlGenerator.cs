using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using Voyager.DbCommandSql.Rules;

namespace Voyager.DbCommandSql
{
	abstract class SqlGenerator
	{

		private readonly DbCommand dbCommand;

		Dictionary<DbType, ParamRule> dictionary;
		public SqlGenerator(DbCommand dbCommand)
		{
			this.dbCommand = dbCommand;

			dictionary = AddRules();
		}

		public string GetSql()
		{
			return Declaration() + GetCallText(dbCommand) + Parameters(dbCommand) + OutputResult(dbCommand);
		}

		private string OutputResult(DbCommand dbCommand)
		{
			string result = string.Empty;
			foreach (DbParameter dbpar in dbCommand.Parameters)
			{
				if (OuptPutType(dbpar.Direction))
				{
					if (string.IsNullOrEmpty(result))
						result += Environment.NewLine + "SELECT ";
					else
						result += ",";
					result += dbpar.ParameterName;
				}
			}
			return result;
		}

		protected string Declaration()
		{
			string paramList = GetParamList();

			if (paramList != string.Empty)
				return "DECLARE" + paramList + Environment.NewLine;

			return string.Empty;
		}

		protected virtual string Parameters(DbCommand dbCommand)
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

		protected abstract string GetCallText(DbCommand dbCommand);

		protected ParamRule GetParamRule(DbType dbType)
		{
			if (dictionary.ContainsKey(dbType))
				return dictionary[dbType];
			return null;
		}

		protected string GetParamList()
		{
			string paramList = string.Empty;

			foreach (DbParameter dbpar in dbCommand.Parameters)
			{
				if (!OuptPutType(dbpar.Direction))
					continue;
				if (!string.IsNullOrEmpty(paramList))
					paramList += ",";
				paramList += $" {dbpar.ParameterName} {TranslateType(dbpar)}";


			}

			return paramList;
		}

		private string TranslateType(DbParameter dbPar)
		{

			ParamRule param = GetParamRule(dbPar.DbType);
			if (param != null)
				return param.GetType(dbPar.DbType) + param.GetTypeSize(dbPar);
			return dbPar.DbType.ToString().ToLower() + dbPar.GetTypeSize();
		}

		protected string GetPrepareValue(DbParameter dbPar)
		{
			ParamRule param = GetParamRule(dbPar.DbType);
			if (param != null)
				return param.GetValue(dbPar.Value);
			return string.Format(CultureInfo.InvariantCulture, "{0:N}", dbPar.Value);
		}


		protected virtual Dictionary<DbType, ParamRule> AddRules()
		{
			var dictionary = new Dictionary<DbType, ParamRule>
			{
				{ DbType.Int32, new Int32Param() },
				{ DbType.String, new StringParam() },
				{ DbType.StringFixedLength, new StringParam() },
				{ DbType.Xml, new StringParam() },

				{ DbType.AnsiString, new AnsiStringParam() },

				{ DbType.DateTime, new DateTimeParam() },
				{ DbType.DateTime2, new DateTimeParam() },

				{ DbType.Boolean, new BoolParam() },
				{ DbType.Byte, new ByteParam() },
				{ DbType.Int16, new Int16Param() },
				{ DbType.Int64, new Int64Param() },

				{ DbType.Object, new TableParam() },

				{ DbType.Decimal, new DecimalParam() }
			};
			return dictionary;
		}


		protected static bool OuptPutType(ParameterDirection direction)
		{
			return direction == ParameterDirection.Output || direction == ParameterDirection.InputOutput;
		}

	}

}
