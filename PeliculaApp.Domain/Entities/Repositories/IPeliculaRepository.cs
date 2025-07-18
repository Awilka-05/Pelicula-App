using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculaApp.Domain.Entities.Repositories
{
    public interface IPeliculaRepository
    {
        List<Pelicula> ObtenerTodas();
        Pelicula ObtenerPorId(int id);
        void Agregar(Pelicula pelicula);
        void Actualizar(Pelicula pelicula, Pelicula existente);
        void Eliminar(int id);
    }
}
