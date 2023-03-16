﻿namespace CarDealer
{
	using System.Globalization;

	using AutoMapper;

	using CarDealer.DTOs.Export;
	using CarDealer.DTOs.Import;
	using CarDealer.Models;

	public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            // Supplier
            this.CreateMap<SupplierDto, Supplier>();

            // Part
            this.CreateMap<PartDto, Part>()
                .ForMember(d => d.SupplierId,
                    opt => opt.MapFrom(s => s.SupplierId.Value));
            this.CreateMap<Part, ExportCarPartDto>();
            
            // Car
            this.CreateMap<CarDto, Car>()
                .ForSourceMember(s => s.Parts, opt => opt.DoNotValidate());
            this.CreateMap<Car, ExportCarDto>();
            this.CreateMap<Car, ExportBmwCarDto>();
            this.CreateMap<Car, ExportCarWithPartsListDto>()
                .ForMember(d => d.Parts,
                        opt => opt.MapFrom(s =>
                            s.PartsCars
                                .Select(pc => pc.Part)
                                .OrderByDescending(p => p.Price)
                                .ToArray()));

            // Customer
            this.CreateMap<CustomerDto, Customer>()
                .ForMember(d => d.BirthDate,
                        opt => opt.MapFrom(s => DateTime.Parse(s.BirthDate, CultureInfo.InvariantCulture)));

            // Sale
            this.CreateMap<SaleDto, Sale>();
        }
    }
}
