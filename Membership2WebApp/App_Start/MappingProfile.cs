using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Membership2WebApp.Dtos;
using Membership2WebApp.Models;

namespace Membership2WebApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
        }
    }
}