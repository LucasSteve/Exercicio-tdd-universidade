using AutoMapper;
using Exercicio09.Api.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Test.Configs
{
    public static class MapConfig
    {
        public static IMapper Get()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            return mockMapper.CreateMapper();
        }
    }
}
