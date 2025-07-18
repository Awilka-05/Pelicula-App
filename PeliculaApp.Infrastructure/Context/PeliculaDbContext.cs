using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using PeliculaApp.Domain.Entities;


namespace PeliculaApp.Infrastructure.Context
{
    public class PeliculaDbContext : DbContext
    {
        public DbSet<Pelicula> Peliculas { get; set; }

        public PeliculaDbContext(DbContextOptions<PeliculaDbContext> options)
            : base(options)
        {
        }
    }
}
