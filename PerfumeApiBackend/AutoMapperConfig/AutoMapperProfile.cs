using AutoMapper;
using PerfumeApiBackend.DTOs;
using PerfumeApiBackend.Models.DataModels;

namespace PerfumeApiBackend.AutoMapperConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Brand, BrandDTO>();
            CreateMap<Volume, VolumeDTO>();
            CreateMap<Gender, GenderDTO>();
            CreateMap<Concentration, ConcentrationDTO>();
            CreateMap<Stock, StockDTO>();
            CreateMap<Perfumery, PerfumeryDTO>()
                .ForMember(dto => dto.Stocks, perfumery => perfumery.MapFrom(property => property.Stocks));
                //.ForMember(dto => dto.Perfumes, perfume => perfume.MapFrom(property => property.Stocks.Select(stock => stock.Perfume)));
            CreateMap<Perfume, PerfumeDTO>()
                .ForMember(dto => dto.Perfumeries, perfume => perfume.MapFrom(property => property.Stocks.Select(stock => stock.Perfumery)));
                

        }

    }
}
