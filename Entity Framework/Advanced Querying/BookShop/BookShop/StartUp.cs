namespace BookShop
{
	using System.Text;

	using Data;
	using Initializer;

	using Microsoft.EntityFrameworkCore;

	public class StartUp
	{
		public static void Main()
		{
			using var db = new BookShopContext();
			DbInitializer.ResetDatabase(db);
		}

		public static string GetBooksByAgeRestriction(BookShopContext context, string command)
		{
			string[] foundBooks = context.Books
				.Where(b => b.AgeRestriction.ToString().ToLower().Equals(command.ToLower()))
				.OrderBy(b => b.Title)
				.Select(b => b.Title)
				.ToArray();

			return string.Join(Environment.NewLine, foundBooks);
		}

		public static string GetGoldenBooks(BookShopContext context)
		{
			string[] foundBooks = context.Books
				.Where(b => b.EditionType.ToString().Equals("Gold") &&
						b.Copies < 5000)
				.OrderBy(b => b.BookId)
				.Select(b => b.Title)
				.ToArray();

			return string.Join(Environment.NewLine, foundBooks);
		}

		public static string GetBooksByPrice(BookShopContext context)
		{
			var foundBooks = context.Books
				.Where(b => b.Price > 40m)
				.OrderByDescending(b => b.Price)
				.Select(b => $"{b.Title} - ${b.Price:F2}")
				.ToArray();

			return string.Join(Environment.NewLine, foundBooks);
		}

		public static string GetBooksNotReleasedIn(BookShopContext context, int year)
		{
			var foundBooks = context.Books
				.Where(b => b.ReleaseDate.Value.Year != year)
				.OrderBy(b => b.BookId)
				.Select(b => b.Title)
				.ToArray();

			return string.Join(Environment.NewLine, foundBooks);
		}

		public static string GetBooksByCategory(BookShopContext context, string input)
		{
			string[] categories = input
				.ToLower()
				.Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

			var foundBooks = context.BooksCategories
				.Include(b => b.Book)
				.Where(b => categories.Contains(b.Category.Name.ToLower()))
				.Select(b => b.Book.Title)
				.OrderBy(b => b)
				.ToArray();

			return string.Join(Environment.NewLine, foundBooks);
		}

		public static string GetBooksReleasedBefore(BookShopContext context, string date)
		{
			var foundBooks = context.Books
				.Where(b => b.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy", null))
				.OrderByDescending(b => b.ReleaseDate)
				.Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}")
				.ToArray();

			return string.Join(Environment.NewLine, foundBooks);
		}

		public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
		{
			var results = context.Authors
				.Where(a => a.FirstName.EndsWith(input))
				.Select(a => $"{a.FirstName} {a.LastName}")
				.OrderBy(a => a)
				.ToArray();

			return string.Join(Environment.NewLine, results);
		}

		public static string GetBookTitlesContaining(BookShopContext context, string input)
		{
			var results = context.Books
				.Where(b => b.Title.Contains(input, StringComparison.InvariantCultureIgnoreCase))
				.Select(b => b.Title)
				.OrderBy(b => b)
				.ToArray();

			return string.Join(Environment.NewLine, results);
		}

		public static string GetBooksByAuthor(BookShopContext context, string input)
		{
			var results = context.Books
				.Where(b => b.Author.LastName
					.StartsWith(input, StringComparison.CurrentCultureIgnoreCase))
				.OrderBy(b => b.BookId)
				.Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
				.ToArray();

			return string.Join(Environment.NewLine, results);
		}

		public static int CountBooks(BookShopContext context, int lengthCheck)
		{
			var books = context.Books
				.Where(b => b.Title.Length > lengthCheck)
				.ToArray();

			return books.Length;
		}

		public static string CountCopiesByAuthor(BookShopContext context)
		{
			var results = context.Authors
				.Select(a => new
				{
					FullName = $"{a.FirstName} {a.LastName}",
					CopiesCount = a.Books.Sum(b => b.Copies)
				})
				.OrderByDescending(a => a.CopiesCount)
				.Select(a => $"{a.FullName} - {a.CopiesCount}")
				.ToArray();

			return string.Join(Environment.NewLine, results);
		}

		public static string GetTotalProfitByCategory(BookShopContext context)
		{
			var results = context.Categories
				.Select(c => new
				{
					c.Name,
					TotalProfit = c.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
				})
				.OrderByDescending(c => c.TotalProfit)
				.ThenBy(c => c.Name)
				.Select(c => $"{c.Name} ${c.TotalProfit:F2}")
				.ToArray();

			return string.Join(Environment.NewLine, results);
		}

		public static string GetMostRecentBooks(BookShopContext context)
		{
			var categories = context.Categories
				.Select(c => new
				{
					CategoryName = c.Name,
					Books = c.CategoryBooks
						.Select(bc => bc.Book)
						.OrderByDescending(b => b.ReleaseDate)
						.Take(3)
				})
				.OrderBy(c => c.CategoryName)
				.ToArray();

			StringBuilder sb = new StringBuilder();

			foreach (var cat in categories)
			{
				sb.AppendLine($"--{cat.CategoryName}");

				foreach (var book in cat.Books)
				{
					sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
				}
			}

			return sb.ToString().Trim();
		}

		public static void IncreasePrices(BookShopContext context)
		{
			var books = context.Books
				.Where(b => b.ReleaseDate.Value.Year < 2010);

			foreach (var book in books)
			{
				book.Price += 5;
			}

			context.SaveChanges();
		}

		public static int RemoveBooks(BookShopContext context)
		{
			var books = context.Books
				.Where(b => b.Copies < 4200);

			int removedCount = books.Count();

			context.Books.RemoveRange(books);
			context.SaveChanges();

			return removedCount;
		}
	}
}