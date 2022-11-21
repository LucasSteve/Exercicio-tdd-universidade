using Exercicio09.Domain.Entities;
using Exercicio09.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Infrastructure.Contexts
{
    public class Exercicio09Context : DbContext
    {
        public Exercicio09Context()
        {
                
        }
        public Exercicio09Context(DbContextOptions<Exercicio09Context> options ) : base(options) 
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Usuario>().HasOne(s => s.Curso).WithMany(s => s.Usuarios).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Usuario>().HasOne(s => s.Endereco).WithMany(s => s.Usuarios).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Departamento>().HasOne(s => s.Endereco).WithMany(s => s.Departamentos).OnDelete(DeleteBehavior.Restrict);           
            modelBuilder.Entity<Curso>(new CursoEntityMap().Configure);


        }

    }



}
