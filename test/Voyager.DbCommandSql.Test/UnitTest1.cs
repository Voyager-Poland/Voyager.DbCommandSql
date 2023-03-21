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
	public void CallEmpty()
	{
		var cmmnd = provider.CreateCommand();
		string test = cmmnd.GetGeneratedQuery();
		Assert.That(test, Is.Empty);
	}


	[Test]
	public void SimpleSelect()
	{
		var cmmnd = provider.CreateCommand();
		cmmnd.CommandText = "SELECT * FROM dbo.Akwizytor";
		string test = cmmnd.GetGeneratedQuery();
		Assert.That(test, Is.EqualTo("SELECT * FROM dbo.Akwizytor"));
	}

	[Test]
	public void SimpleSelectParam()
	{
		var cmmnd = provider.CreateCommand();
		cmmnd.CommandText = "SELECT * FROM dbo.Akwizytor WHERE IdAkwizytor=@IdAkwizytor";

		var parametr = provider.CreateParameter();
		parametr.ParameterName = "@IdAkwizytor";
		parametr.DbType = System.Data.DbType.AnsiString;
		parametr.Value = "TESTAKWIZYTOR1";

		cmmnd.Parameters.Add(parametr);

		string test = cmmnd.GetGeneratedQuery();
		Assert.That(test, Is.EqualTo("SELECT * FROM dbo.Akwizytor WHERE IdAkwizytor='TESTAKWIZYTOR1'"));
	}



	[Test]
	public void SimpleSelectOutput()
	{
		var cmmnd = provider.CreateCommand();
		cmmnd.CommandText = "SELECT top 1 @Pout = NazwaA FROM dbo.Akwizytor WHERE IdAkwizytor=@IdAkwizytor";

		var parametr = provider.CreateParameter();
		parametr.ParameterName = "@IdAkwizytor";
		parametr.DbType = System.Data.DbType.AnsiString;
		parametr.Value = "TESTAKWIZYTOR1";

		var parametrout = provider.CreateParameter();
		parametrout.ParameterName = "@Pout";
		parametrout.DbType = System.Data.DbType.String;
		parametrout.Direction = System.Data.ParameterDirection.Output;
		parametrout.Size = 100;


		cmmnd.Parameters.Add(parametr);
		cmmnd.Parameters.Add(parametrout);

		string test = cmmnd.GetGeneratedQuery();
		Assert.That(test, Is.EqualTo("DECLARE @Pout nvarchar(100)" + Environment.NewLine + "SELECT top 1 @Pout = NazwaA FROM dbo.Akwizytor WHERE IdAkwizytor='TESTAKWIZYTOR1'" + Environment.NewLine + "SELECT @Pout"));
	}


	[Test]
	public void CimpleCall()
	{
		var cmd = provider.CreateCommand();
		cmd.CommandText = "dbo.sp_Call1";
		cmd.CommandType = System.Data.CommandType.StoredProcedure;

		var parametr = provider.CreateParameter();
		parametr.ParameterName = "@IdAkwizytor";
		parametr.DbType = System.Data.DbType.AnsiString;
		parametr.Value = "TESTAKWIZYTOR1";


		var parametrint = provider.CreateParameter();
		parametrint.ParameterName = "@NrZlec";
		parametrint.DbType = System.Data.DbType.Int32;
		parametrint.Value = 22;


		var parametrout = provider.CreateParameter();
		parametrout.ParameterName = "@Pout";
		parametrout.DbType = System.Data.DbType.String;
		parametrout.Direction = System.Data.ParameterDirection.Output;
		parametrout.Size = 100;



		cmd.Parameters.Add(parametr);
		cmd.Parameters.Add(parametrint);
		cmd.Parameters.Add(parametrout);

		string test = cmd.GetGeneratedQuery();
		Assert.That(test, Is.EqualTo("DECLARE @Pout nvarchar(100)\r\nEXEC dbo.sp_Call1 @IdAkwizytor='TESTAKWIZYTOR1', @NrZlec=22, @Pout=@Pout OUTPUT\r\nSELECT @Pout"));
	}

}