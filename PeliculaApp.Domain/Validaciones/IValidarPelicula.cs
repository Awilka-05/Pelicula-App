using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeliculaApp.Domain.Entities;

namespace PeliculaApp.Domain.Validaciones
{
    public interface IValidarPelicula
    {
        void Validar(Pelicula pelicula);
    }
}
