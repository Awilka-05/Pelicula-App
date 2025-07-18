using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeliculaApp.Domain.Entities;

namespace PeliculaApp.Application.Services
{
    public interface IPeliculaService
    {
        List<Pelicula> ObtenerTodas();
        Pelicula ObtenerPorId(int id);
        void Crear(Pelicula pelicula);
        void Actualizar(Pelicula pelicula);
        void Eliminar(int id);

    }
}
