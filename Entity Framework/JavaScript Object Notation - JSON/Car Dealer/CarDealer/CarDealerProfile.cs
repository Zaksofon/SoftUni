using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.DTO.InputModels;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SuppliersInputDto, Supplier>();
            CreateMap<CustomersInputDto, Customer>();
            CreateMap<SalaesInputDto, Sale>();
        }
    }
}
