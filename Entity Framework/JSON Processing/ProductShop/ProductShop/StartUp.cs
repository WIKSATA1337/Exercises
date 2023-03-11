namespace ProductShop;

using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.Models;

public class StartUp
{
    public static void Main()
    {
        using var context = new ProductShopContext();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        //01. Import Users
        //var usersJSON = File.ReadAllText("./../../../Datasets/users.json");
        //ImportUsers(context, usersJSON);

        //02. Import Products
        //var productsJSON = File.ReadAllText("./../../../Datasets/products.json");
        //ImportProducts(context, productsJSON);

        //03. Import Categories
        //var categoriesJSON = File.ReadAllText("./../../../Datasets/categories.json");
        //ImportCategories(context, categoriesJSON);

        //04. Import CategoriesProducts
        //var cpJSON = File.ReadAllText("./../../../Datasets/categories-products.json");
        //ImportCategoryProducts(context, cpJSON);

        //05. Export Products In Range
        //File.WriteAllText("./../../../Results/products-in-range.json", GetProductsInRange(context));
    }

    public static string ImportUsers(ProductShopContext context, string inputJson)
    {
        User[]? users = JsonConvert.DeserializeObject<User[]>(inputJson);

        context.Users.AddRange(users);
        context.SaveChanges();

        return $"Successfully imported {users.Length}";
    }

    public static string ImportProducts(ProductShopContext context, string inputJson)
    {
        Product[]? products = JsonConvert.DeserializeObject<Product[]>(inputJson);

        context.Products.AddRange(products);
        context.SaveChanges();

        return $"Successfully imported {products.Length}";
    }

    public static string ImportCategories(ProductShopContext context, string inputJson)
    {
        Category[]? categories = JsonConvert.DeserializeObject<Category[]>(inputJson);

        context.Categories.AddRange(categories);
        context.SaveChanges();

        return $"Successfully imported {categories.Length}";
    }

    public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
    {
        CategoryProduct[]? cp = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

        context.CategoriesProducts.AddRange(cp);
        context.SaveChanges();

        return $"Successfully imported {cp.Length}";
    }

    public static string GetProductsInRange(ProductShopContext context)
    {
        var result = context.Products
            .Where(p => p.Price >= 500 && p.Price <= 1000)
            .OrderBy(p => p.Price)
            .Select(p => new ProductInRangeDto
            {
                Name = p.Name,
                Price = p.Price,
                Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
            })
            .ToList();

        return JsonConvert.SerializeObject(result, Formatting.Indented);
    }
}