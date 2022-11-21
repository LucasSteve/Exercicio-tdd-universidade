using Bogus;
using Exercicio09.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Test.Fakers
{
    public static class ApiCepFakers
    {
        private static readonly Faker Fake = new Faker();

        public static AppSetting CepOptions() => new AppSetting
        {
            ApiCep = Fake.Internet.Url()
        };

    }
}
