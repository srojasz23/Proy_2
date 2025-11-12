using System.Collections.Generic;
using Entidad;
using Datos;

namespace Negocio
{
    public class AlumnoServicio
    {
        private readonly IAlumnoRepositorio _repo;

        public AlumnoServicio(IAlumnoRepositorio repo)
        {
            _repo = repo;
        }

        public IEnumerable<Alumno> Listar() => _repo.Listar();

        public void Agregar(Alumno alumno)
        {
            if (string.IsNullOrWhiteSpace(alumno.Nombre))
                throw new System.ArgumentException("El nombre es obligatorio");
            _repo.Agregar(alumno);
        }
    }
}
