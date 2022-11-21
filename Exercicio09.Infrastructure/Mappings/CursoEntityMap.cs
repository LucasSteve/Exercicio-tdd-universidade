using Exercicio09.Domain.Entities;
using Exercicio09.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Infrastructure.Mappings
{
    public class CursoEntityMap : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.Property(p => p.Turno).HasConversion(
                     prop => prop.ToString(),
                     prop => (Turno)Enum.Parse(typeof(Turno), prop)
                 );

        }
    }
}
