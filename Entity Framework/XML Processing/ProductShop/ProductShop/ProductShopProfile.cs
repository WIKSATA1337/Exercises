namespace ProductShop
{
	using AutoMapper;
	using ProductShop.DTOs.Export;
	using ProductShop.DTOs.Import;
	using ProductShop.Models;

	public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            // User
            this.CreateMap<ImportUserDto, User>();
			this.CreateMap<User, ExportUserSoldProductsDto>()
				.ForMember(d => d.SoldProducts,
					opt => opt.MapFrom(s => s.ProductsSold));

			// Product
			this.CreateMap<ImportProductDto, Product>();
			this.CreateMap<Product, ExportProductsInRangeDto>()
				.ForMember(d => d.Buyer,
					opt => opt.MapFrom(s => $"{s.Buyer.FirstName} {s.Buyer.LastName}"));
			this.CreateMap<Product, ExportSoldProductDto>();

			// Category
			this.CreateMap<ImportCategoryDto, Category>();
			this.CreateMap<Category, ExportCategoryByProductsDto>()
				.ForMember(d => d.Count,
					opt => opt.MapFrom(s => s.CategoryProducts.Count()))
				.ForMember(d => d.AveragePrice,
					opt => opt.MapFrom(s => s.CategoryProducts
						.Average(cp => cp.Product.Price)))
				.ForMember(d => d.TotalRevenue,
					opt => opt.MapFrom(s => s.CategoryProducts
						.Sum(cp => cp.Product.Price)));

			// CategoryProducts
			this.CreateMap<ImportCategoryProductDto, CategoryProduct>();
		}
	}
}
