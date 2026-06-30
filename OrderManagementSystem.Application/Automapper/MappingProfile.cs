using AutoMapper;
using OrderManagementSystem.Application.DTOs;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Application.Automapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //createMap<source, distination>
            CreateMap<RegisterUserDto, Customer>();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDisplayDto>();
        }
    }
}
