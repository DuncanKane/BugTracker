﻿using AutoMapper;
using BugTracker.Data.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Infrastructure
{    
    public static class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg => {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
    
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<byte, TicketPriority>().ConvertUsing(x => Enum.GetValues(typeof(TicketPriority)).Cast<TicketPriority>().First(y => (byte)y == x));

            CreateMap<BugTracker.Data.Entities.Ticket, BugTracker.Core.Entities.Ticket>();
           
        }
    }
}