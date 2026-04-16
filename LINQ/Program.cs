using LINQ.DataSources;

namespace LINQ;

internal class Program
{
	static void Main(string[] args)
	{


		var result = Source.ProductList
			.Where(p => p.Category == "Seafood")
			.Select(p => new { p.ProductName, p.UnitPrice }).ToList();

		foreach (var item in result)
		{
			Console.WriteLine(item);
		}


		var allProductName = Source.ProductList
			.Select(p => new { p.ProductName }).ToList();


		foreach (var item in allProductName)
		{
			Console.WriteLine(item);
		}


		var result2 = Source.ProductList
		.OrderBy(o => o.UnitPrice)
		.Select(o => new { o.ProductName, o.UnitPrice }).ToList();

		foreach (var item in result2)
		{
			Console.WriteLine(item);
		}

		var result3 = Source.ProductList
			.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30)
			.Select(p => new { p.ProductName, p.UnitPrice }).ToList();

		foreach (var item in result3)
		{
			Console.WriteLine(item);
		}



		var result4 = Source.ProductList
		.Where(p => p.UnitsInStock > 0 && p.Category == "Condiments")
		.Select(p => new { p.Category });



		var result5 = Source.ProductList
			.Select(p =>
			new
			{
				Name = p.ProductName,
				Price = p.UnitPrice,
				StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stuck"
			});

		foreach (var item in result5)
		{
			Console.WriteLine($"Name: {item.Name}, Price: {item.Price}, Stock Status: {item.StockStatus}");
		}

		var result6 = Source.ProductList
	.Select((p, i) => new
	{
		p.ProductName,
		Position = i + 1
	});

		foreach (var item in result6)
		{
			Console.WriteLine($"{item.Position}.{item.ProductName} ");


		}

		var result7 = Source.ProductList
			.OrderBy(p => p.Category)
			.ThenByDescending(p => p.UnitPrice);

		var result8 = Source.ProductList
			.Where(p => p.Category == "Beverages")
			.OrderByDescending(p => p.UnitsInStock)
			.Select(p => new
			{
				p.ProductName,
				p.UnitsInStock
			}
			).ToList();
		foreach (var item in result8)
		{
			Console.WriteLine(item);
		}


		var result9 = from p in Source.CustomerList
					  from o in p.Orders
					  where o.OrderDate.Year >= 1997
					  select new
					  {

						  OrderID = o.OrderID,
						  OrderDate = o.OrderDate
					  };

		var result10 = Source.ProductList
			.Select((p, i) => new
			{
				p.ProductName,
				position = i + 1
			}).ToList();

		String[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

		var sortedWords = Arr
			.OrderBy(S => S.Length)
			.ThenBy(S => S, StringComparer.OrdinalIgnoreCase).ToList();

		foreach (var word in sortedWords)
		{
			Console.WriteLine(word);
		}



		var letterReversed = Arr
			.Where(a=>a.Length>1 && a[1]=='i')
			.Reverse()
			.ToList();






















	}
}
