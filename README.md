# RoundedFrame

Use one of these packages:

| Version | Package | Description |
| ------- | ------- | ----------- |
| [![NuGet Package](https://img.shields.io/nuget/v/sqlite-net-pcl.svg)](https://www.nuget.org/packages/sqlite-net-pcl) | [sqlite-net-pcl](https://www.nuget.org/packages/sqlite-net-pcl) | .NET Standard Library |
| [![NuGet Package with Encryption](https://img.shields.io/nuget/v/sqlite-net-sqlcipher.svg)](https://www.nuget.org/packages/sqlite-net-sqlcipher) | [sqlite-net-sqlcipher](https://www.nuget.org/packages/sqlite-net-sqlcipher) | With Encryption Support |

Simply add a custom frame control that supports four independent corner radius values to your Xamarin project.

SQLite-net was designed as a quick and convenient database layer. Its design follows from these *goals*:
* Very easy to integrate with existing projects and runs on all the .NET platforms.

## NuGet Installation

Install [Plugin.RoundedFrame](https://www.nuget.org/packages/) from NuGet.

**Important:** You will need to add the NuGet package to **both** your *.NET Standard library project* and your *platform-dependent app project*.

## Source Installation

SQLite-net is all contained in 1 file (I know, so cool right?) and is easy to add to your project. Just add [SQLite.cs](https://github.com/praeclarum/sqlite-net/blob/master/src/SQLite.cs) to your project, and you're ready to start creating tables. 

## Please Contribute!

This is an open source project that welcomes contributions/suggestions/bug reports from those who use it. If you have any ideas on how to improve the library, please [post an issue here on GitHub](https://github.com/praeclarum/sqlite-net/issues). Please check out the [How to Contribute](https://github.com/praeclarum/sqlite-net/wiki/How-to-Contribute).

```csharp
public class Stock
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string Symbol { get; set; }
}

public class Valuation
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	[Indexed]
	public int StockId { get; set; }
	public DateTime Time { get; set; }
	public decimal Price { get; set; }
}
```

## Thank you!

Thank you to the .NET community for embracing this project, and thank you to all the contributors who have helped to make this great.

Thanks also to Tirza van Dijk (@tirzavdijk) for the great logo!
