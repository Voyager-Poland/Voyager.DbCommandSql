using System.Data.Common;

namespace Voyager.DbCommandSql.Test;

public class Tests
{
	private DbProviderFactory provider;

	[SetUp]
	public void Setup()
	{
		DefaultProvider defaultProvider = new DefaultProvider();
		provider = defaultProvider.GetProvider();
	}


	[Test]
	public void SimpleSelectParam()
	{
		var cmd = provider.CreateCommand();
		cmd.CommandText = "SELECT * FROM dbo.Akwizytor WHERE IdAkwizytor=@IdAkwizytor";

		var parametr = provider.CreateParameter();
		parametr.ParameterName = "@IdAkwizytor";
		parametr.DbType = System.Data.DbType.AnsiString;
		parametr.Value = "TESTAKWIZYTOR1";

		cmd.Parameters.Add(parametr);

		string test = cmd.GetSql();
		Assert.That(test, Is.EqualTo("SELECT * FROM dbo.Akwizytor WHERE IdAkwizytor='TESTAKWIZYTOR1'"));
	}


	[Test]
	public void SimpleSelect()
	{
		var cmmnd = provider.CreateCommand();
		cmmnd.CommandText = "SELECT * FROM dbo.Akwizytor";
		string test = cmmnd.GetSql();
		Assert.That(test, Is.EqualTo("SELECT * FROM dbo.Akwizytor"));
	}


	[Test]
	public void CallEmpty()
	{
		var cmmnd = provider.CreateCommand();
		string test = cmmnd.GetSql();
		Assert.That(test, Is.Empty);
	}








	[Test]
	public void SimpleSelectOutput()
	{
		var cmd = provider.CreateCommand();
		cmd.CommandText = "SELECT top 1 @Pout = NazwaA FROM dbo.Akwizytor WHERE IdAkwizytor=@IdAkwizytor";

		{
			var parametr = provider.CreateParameter();
			parametr.ParameterName = "@IdAkwizytor";
			parametr.DbType = System.Data.DbType.AnsiString;
			parametr.Value = "TESTAKWIZYTOR1";
			cmd.Parameters.Add(parametr);
		}

		{
			var parametrout = provider.CreateParameter();
			parametrout.ParameterName = "@Pout";
			parametrout.DbType = System.Data.DbType.String;
			parametrout.Direction = System.Data.ParameterDirection.Output;
			parametrout.Size = 100;
			cmd.Parameters.Add(parametrout);
		}

		string test = cmd.GetSql();
		Assert.That(test, Is.EqualTo("DECLARE @Pout nvarchar(100)" + Environment.NewLine + "SELECT top 1 @Pout = NazwaA FROM dbo.Akwizytor WHERE IdAkwizytor='TESTAKWIZYTOR1'" + Environment.NewLine + "SELECT @Pout"));
	}


	[Test]
	public void SimpleCall()
	{
		var cmd = provider.CreateCommand();
		cmd.CommandText = "dbo.sp_Call1";
		cmd.CommandType = System.Data.CommandType.StoredProcedure;

		{
			var parametr = provider.CreateParameter();
			parametr.ParameterName = "@IdAkwizytor";
			parametr.DbType = System.Data.DbType.AnsiString;
			parametr.Value = "TESTAKWIZYTOR1";
			cmd.Parameters.Add(parametr);

		}

		{
			var parametrint = provider.CreateParameter();
			parametrint.ParameterName = "@NrZlec";
			parametrint.DbType = System.Data.DbType.Int32;
			parametrint.Value = 22;
			cmd.Parameters.Add(parametrint);

		}
		{
			var parametrout = provider.CreateParameter();
			parametrout.ParameterName = "@Pout";
			parametrout.DbType = System.Data.DbType.String;
			parametrout.Direction = System.Data.ParameterDirection.Output;
			parametrout.Size = 100;
			cmd.Parameters.Add(parametrout);
		}

		{
			var paramDecim = provider.CreateParameter();
			paramDecim.ParameterName = "@Dec1";
			paramDecim.DbType = System.Data.DbType.Decimal;
			paramDecim.Direction = System.Data.ParameterDirection.Output;
			paramDecim.Precision = 8;
			paramDecim.Scale = 4;

			cmd.Parameters.Add(paramDecim);
		}


		{
			var paramDecim = provider.CreateParameter();
			paramDecim.ParameterName = "@Dec2";
			paramDecim.DbType = System.Data.DbType.Decimal;
			paramDecim.Direction = System.Data.ParameterDirection.Input;
			paramDecim.Precision = 8;
			paramDecim.Scale = 4;
			paramDecim.Value = (decimal)433.2321;
			cmd.Parameters.Add(paramDecim);
		}

		{
			var paramdate = provider.CreateParameter();
			paramdate.ParameterName = "@DataOut";
			paramdate.DbType = System.Data.DbType.DateTime;
			paramdate.Direction = System.Data.ParameterDirection.Output;

			cmd.Parameters.Add(paramdate);
		}

		{
			var paramdate = provider.CreateParameter();
			paramdate.ParameterName = "@DataInt";
			paramdate.DbType = System.Data.DbType.DateTime;
			paramdate.Direction = System.Data.ParameterDirection.Input;
			paramdate.Value = new DateTime(2023, 03, 21, 12, 13, 45);
			cmd.Parameters.Add(paramdate);
		}

		string test = cmd.GetSql();
		Console.WriteLine(test);
		Assert.That(test, Is.EqualTo("DECLARE @Pout nvarchar(100), @Dec1 decimal(8,4), @DataOut datetime\r\nEXEC dbo.sp_Call1 @IdAkwizytor='TESTAKWIZYTOR1', @NrZlec=22, @Pout=@Pout OUTPUT, @Dec1=@Dec1 OUTPUT, @Dec2=433.2321, @DataOut=@DataOut OUTPUT, @DataInt='2023-03-21 12:13:45.000'\r\nSELECT @Pout,@Dec1,@DataOut"));
	}

}