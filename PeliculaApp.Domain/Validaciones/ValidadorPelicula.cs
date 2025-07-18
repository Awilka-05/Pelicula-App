using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeliculaApp.Domain.Entities;
using PeliculaApp.Domain.Entities.Repositories;


namespace PeliculaApp.Domain.Validaciones
{
   
    public class ValidadorPelicula : IValidarPelicula
    {
        private readonly IPeliculaRepository _repositorio;

        public ValidadorPelicula(IPeliculaRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public void Validar(Pelicula pelicula)
        {
         
            if (string.IsNullOrWhiteSpace(pelicula.Titulo))
                throw new ArgumentException("El titulo es obligatorio");

            if (string.IsNullOrWhiteSpace(pelicula.Genero))
                throw new ArgumentException("El genero es obligatorio");

            if (string.IsNullOrWhiteSpace(pelicula.Director))
                throw new ArgumentException("El director es obligatorio");

            var duplicada = _repositorio.ObtenerTodas()
           .Any(p => p.Id != pelicula.Id && p.Titulo.Equals(pelicula.Titulo, StringComparison.OrdinalIgnoreCase));

            if (duplicada)
                throw new InvalidOperationException("Ya existe una pelicula con el mismo titulo.");

           
        }
    }
    
}
