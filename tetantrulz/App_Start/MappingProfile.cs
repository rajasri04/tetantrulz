using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tetantrulz.Dtos;
using tetantrulz.Models;

namespace tetantrulz.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();
            Mapper.CreateMap<demo, demoDTO>();
            Mapper.CreateMap<demoDTO, demo>();
            Mapper.CreateMap<movie, movieDTO>();
            Mapper.CreateMap<movieDTO, movie>();
        }
    }
}