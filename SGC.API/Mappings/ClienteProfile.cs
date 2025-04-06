using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SGC.Domain.Entities;
using SGC.API.DTOs;

namespace SGC.API.Mappings
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
        }

    }
}