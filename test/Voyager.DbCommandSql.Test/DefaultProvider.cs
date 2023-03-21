using System.Data.Common;
using System.Data.SqlClient;

namespace Voyager.DbCommandSql.Test
{
	public class DefaultProvider
	{
		static DefaultProvider()
		{
			DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", SqlClientFactory.Instance);
		}

		public DbProviderFactory GetProvider()
		{
			return DbProviderFactories.GetFactory("Microsoft.Data.SqlClient");
		}
	}
}
