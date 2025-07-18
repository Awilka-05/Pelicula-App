using PeliculaApp.Domain.Entities;
using PeliculaApp.Domain.Entities.Repositories;
using PeliculaApp.Domain.Validaciones;

namespace PeliculaApp.Application.Services
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaRepository _repositorio;
        private readonly IValidarPelicula _validador;
        public PeliculaService(IPeliculaRepository repositorio, IValidarPelicula validador)
        {
            _repositorio = repositorio;
            _validador = validador;
        }

        public List<Pelicula> ObtenerTodas() 
        {
            return _repositorio.ObtenerTodas();
        }

        public Pelicula ObtenerPorId(int id)  
        {
            var pelicula = _repositorio.ObtenerPorId(id);
            if (pelicula == null)
                throw new ArgumentException("La pelicula con ese ID no existe.");
            return pelicula;
        }

        public void Crear(Pelicula pelicula)  
        {
            _validador.Validar(pelicula);
            _repositorio.Agregar(pelicula);
        }

        public void Actualizar(Pelicula pelicula) 
        {
            var existente = _repositorio.ObtenerPorId(pelicula.Id);
            if (existente == null)
                throw new InvalidOperationException("La película no existe.");

            _validador.Validar(pelicula);
            _repositorio.Actualizar(pelicula, existente);
        }

        public void Eliminar(int id) 
        {
            if (_repositorio.ObtenerPorId(id) == null)
                throw new ArgumentException("No se puede eliminar. La pelicula no existe.");
            _repositorio.Eliminar(id);
        }


    }
}
