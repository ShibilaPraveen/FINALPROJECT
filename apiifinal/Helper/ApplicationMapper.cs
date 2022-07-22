using apiifinal.Data;
using apiifinal.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiifinal.Helper
{
    public class ApplicationMapper :Profile
    {
        public ApplicationMapper()
        {
            CreateMap<PortSlots, PortSlot>().ReverseMap();
            CreateMap<PortUsers, PortUser>().ReverseMap();
        }
    }
}
