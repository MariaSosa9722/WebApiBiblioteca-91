﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WepApi91.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        //Modelos 
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }   
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Insertar en la tabla usuario
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario= 1,
                    Nombre = "Majo",
                    User = "Usuario1",
                    Password = "123",
                    FkRol = 1

                }
            );

            //Insertar en la tabla rol
            modelBuilder.Entity<Rol>().HasData(
            new Rol
            {
                PkRol= 1,
                Nombre= "sa"

            });

        }


    }
}
