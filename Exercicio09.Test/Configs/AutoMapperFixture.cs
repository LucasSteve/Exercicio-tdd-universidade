using AutoMapper;
using Exercicio09.Api.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Test.Configs
{
    public abstract class BaseAutoMapperFixture
    {
        public IMapper mapper { get; set; }

        public BaseAutoMapperFixture()
        {
            mapper = new AutoMapperFixture().GetMapper();
        }

    }

    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            return config.CreateMapper();
        }

        public void Dispose() { }
    }
}
