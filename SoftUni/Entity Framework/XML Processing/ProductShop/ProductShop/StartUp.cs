namespace ProductShop
{
	using AutoMapper;
	using AutoMapper.QueryableExtensions;
	using Microsoft.EntityFrameworkCore;

	using ProductShop.Data;
	using ProductShop.DTOs.Export;
	using ProductShop.DTOs.Import;
	using ProductShop.Models;
	using ProductShop.Utilities;

	public class StartUp
    {
        public static void Main()
        {
			using ProductShopContext context = new ProductShopContext();

			// Importing code:
			// string xml = File.ReadAllText("../../../Datasets/dataSetName.xml");
			// Console.WriteLine(MethodName(context, xml));

			// Exporting code
			//Console.WriteLine(MethodName(context));
		}

		public static string ImportUsers(ProductShopContext context, string inputXml)
		{
			IMapper mapper = InitializeMapper();
			XmlHelper helper = new XmlHelper();

			ImportUserDto[] userDtos = helper.Deserialize<ImportUserDto[]>(inputXml, "Users");

			User[] users = mapper.Map<User[]>(userDtos);

			context.Users.AddRange(users);
			context.SaveChanges();

			return $"Successfully imported {users.Length}";
		}

		public static string ImportProducts(ProductShopContext context, string inputXml)
		{
			IMapper mapper = InitializeMapper();
			XmlHelper helper = new XmlHelper();

			ImportProductDto[] productDtos = helper.Deserialize<ImportProductDto[]>(inputXml, "Products");

			Product[] products = mapper.Map<Product[]>(productDtos);

			context.Products.AddRange(products);
			context.SaveChanges();

			return $"Successfully imported {products.Length}";
		}
		
		public static string ImportCategories(ProductShopContext context, string inputXml)
		{
			IMapper mapper = InitializeMapper();
			XmlHelper helper = new XmlHelper();

			ImportCategoryDto[] categoryDtos =
				helper.Deserialize<ImportCategoryDto[]>(inputXml, "Categories");

			ICollection<Category> validCategories = new HashSet<Category>();

			foreach (var categoryDto in categoryDtos)
			{
				if (!string.IsNullOrEmpty(categoryDto.Name))
				{
					var category = mapper.Map<Category>(categoryDto);
					validCategories.Add(category);
				}
			}

			context.Categories.AddRange(validCategories);
			context.SaveChanges();

			return $"Successfully imported {validCategories.Count}";
		}

		public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
		{
			IMapper mapper = InitializeMapper();
			XmlHelper helper = new XmlHelper();

			ImportCategoryProductDto[] cpDtos =
				helper.Deserialize<ImportCategoryProductDto[]>(inputXml, "CategoryProducts");

			ICollection<CategoryProduct> validCps = new HashSet<CategoryProduct>();

			List<int> categoriesIds = context.Categories
				.AsNoTracking()
				.Select(c => c.Id)
				.ToList();

			List<int> productsIds = context.Products
				.AsNoTracking()
				.Select(c => c.Id)
				.ToList();

			foreach (var cpDto in cpDtos)
			{
				if (productsIds.Any(p => p == cpDto.ProductId) &&
					categoriesIds.Any(c => c == cpDto.CategoryId))
				{
					var cp = mapper.Map<CategoryProduct>(cpDto);
					validCps.Add(cp);
				}
			}

			context.CategoryProducts.AddRange(validCps);
			context.SaveChanges();

			return $"Successfully imported {validCps.Count}";
		}

		public static string GetProductsInRange(ProductShopContext context)
		{
			IMapper mapper = InitializeMapper();
			XmlHelper helper = new XmlHelper();

			var products = context.Products
				.Where(p => p.Price >= 500 && p.Price <= 1000)
				.OrderBy(p => p.Price)
				.ProjectTo<ExportProductsInRangeDto>(mapper.ConfigurationProvider)
				.Take(10)
				.ToArray();

			return helper.Serialize(products, "Products");
		}

		public static string GetSoldProducts(ProductShopContext context)
		{
			IMapper mapper = InitializeMapper();
			XmlHelper helper = new XmlHelper();

			var users = context.Users
				.Where(u => u.ProductsSold.Any())
				.OrderBy(u => u.LastName)
				.ThenBy(u => u.FirstName)
				.ProjectTo<ExportUserSoldProductsDto>(mapper.ConfigurationProvider)
				.Take(5)
				.ToArray();

			return helper.Serialize(users, "Users");
		}

		// For some reason this doesnt work locally (on my pc) but Judge accepts it.
		public static string GetCategoriesByProductsCount(ProductShopContext context)
		{
			IMapper mapper = InitializeMapper();
			XmlHelper helper = new XmlHelper();

			var categories = context.Categories
				.ProjectTo<ExportCategoryByProductsDto>(mapper.ConfigurationProvider)
				.OrderByDescending(c => c.Count)
				.ThenBy(c => c.TotalRevenue)
				.ToArray();

			return helper.Serialize(categories, "Categories");
		}

		public static string GetUsersWithProducts(ProductShopContext context)
		{
			XmlHelper helper = new XmlHelper();

			var usersInfo = context.Users
				.Where(u => u.ProductsSold.Any())
				.OrderByDescending(u => u.ProductsSold.Count)
				.Select(u => new UserInfo
				{
					FirstName = u.FirstName,
					LastName = u.LastName,
					Age = u.Age,
					SoldProducts = new SoldProductsCount
					{
						Count = u.ProductsSold.Count,
						Products = u.ProductsSold.Select(p => new SoldProduct	
						{
							Name = p.Name,
							Price = p.Price
						})
						.OrderByDescending(p => p.Price)
						.ToArray()
					}
				})
				.Take(10)
				.ToArray();

			ExportUserCountDto exportUserCountDto = new ExportUserCountDto
			{
				Count = context.Users.Count(u => u.ProductsSold.Any()),
				Users = usersInfo
			};

			return helper.Serialize(exportUserCountDto, "Users");
		}

		private static IMapper InitializeMapper()
			=> new Mapper(new MapperConfiguration(cfg =>
				cfg.AddProfile<ProductShopProfile>()));
	}
}