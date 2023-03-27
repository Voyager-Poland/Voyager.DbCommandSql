using System;
using System.Data;
using System.Data.Common;

namespace Voyager.DbCommandSql.Rules
{
	internal abstract class ParamRule
	{
		private readonly TypeSize typeSize;
		public ParamRule(TypeSize typeSize)
		{
			this.typeSize = typeSize;
		}

		public ParamRule()
		{
			this.typeSize = new TypeSizeFixed();
		}


		public virtual string GetType(DbType type)
		{
			return type.ToString().ToLower();
		}

		public virtual string GetValue(object dbValue)
		{
			if (dbValue == null || dbValue == DBNull.Value)
				return "NULL";
			else
				return dbValue.ToString();
		}

		public string GetTypeSize(DbParameter dbParam)
		{
			return typeSize.GetTypeSize(dbParam);
		}

	}


	abstract class TypeSize
	{
		public abstract string GetTypeSize(DbParameter dbParam);
	}

	class TypeSizeEmpty : TypeSize
	{
		public override string GetTypeSize(DbParameter dbParam)
		{
			return string.Empty;
		}
	}

	class TypeSizeFixed : TypeSize
	{
		public override string GetTypeSize(DbParameter dbParam)
		{
			return dbParam.GetTypeSize();
		}
	}
}
