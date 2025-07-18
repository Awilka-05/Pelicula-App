using Microsoft.EntityFrameworkCore;
using PeliculaApp.Application.Services;
using PeliculaApp.Domain.Entities;
using PeliculaApp.Domain.Entities.Repositories;
using PeliculaApp.Infrastructure.Context;

namespace PeliculaApp.Infrastructure.Repository
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly PeliculaDbContext _context;

        public PeliculaRepository(PeliculaDbContext context)
        {
            _context = context;
        }

        public List<Pelicula> ObtenerTodas()
        {
            return _context.Peliculas.ToList();
        }

        public Pelicula ObtenerPorId(int id)
        {
            return _context.Peliculas.FirstOrDefault(p => p.Id == id);
        }

        public void Agregar(Pelicula pelicula)  
        {
            _context.Peliculas.Add(pelicula);
            _context.SaveChanges();
        }

        public void Actualizar(Pelicula pelicula, Pelicula existente)
        {
           
            _context.Entry(existente).CurrentValues.SetValues(pelicula);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var pelicula = ObtenerPorId(id);
            if (pelicula != null)
            {
                _context.Peliculas.Remove(pelicula);
                _context.SaveChanges();
            }
        }
    }
}
