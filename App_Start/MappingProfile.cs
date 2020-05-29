using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_API.Models;
using TMS_API.ViewModels;

namespace TMS_API.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<TicketViewModel, Ticket>();
            Mapper.CreateMap<Ticket, TicketViewModel>();
        }
    }
}