using AutoMapper;
using Mkopa.Core.DTO;
using Mkopa.Core.ServiceBusContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mkopa.Core.AutoMapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SendSMSDto, SendSMSContract>()
           .ForMember(x => x.SmsText, y => { y.MapFrom(p => p.SmsText); })
           .ForMember(x => x.PhoneNumber, y => { y.MapFrom(p => p.PhoneNumber); })
           .ForMember(x => x.MessageKey, y => { y.MapFrom(p => Guid.NewGuid()); })
           .ReverseMap();
        }

       
    }
}
