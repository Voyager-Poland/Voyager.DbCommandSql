# Voyager.DbCommandSql
 Generate SQL text query from DbCommand. Can be used for unit test and integration test purposes.


## How to use it

There is added extension to the DbCommand class GetGeneratedQuery. This is an example of how to use:

```C#
using System.Data.Common;

  [Test]
  public void SimpleSelectParam()
  {
    var cmd = provider.CreateCommand();
 
...

    string test = cmd.GetSql();
    Assert.That(test, Is.EqualTo("SELECT * FROM dbo.Akwizytor WHERE IdAkwizytor='TESTAKWIZYTOR1'"));
  }
```

## ✍️ Authors 

- [@andrzejswistowski](https://github.com/AndrzejSwistowski) - Idea & work. Please let me know if you find out an error or suggestions.

[contributors](https://github.com/Voyager-Poland).

## 🎉 Acknowledgements 

- Przemysław Wróbel - for the icon.