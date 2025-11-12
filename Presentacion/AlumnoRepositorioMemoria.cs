using System.Collections.Generic;
using System.Linq;
using Entidad;

namespace Datos
{
    public class AlumnoRepositorioMemoria : IAlumnoRepositorio
    {
        private readonly List<Alumno> _data = new();

        public AlumnoRepositorioMemoria()
        {
            _data.AddRange(new[]
            {
                new Alumno{ Id=1, Nombre="Ana", Apellido="Soldevilla", Seccion="A", Ciclo="2025-1" },
                new Alumno{ Id=2, Nombre="José", Apellido="Mendoza", Seccion="A", Ciclo="2025-1" },
                new Alumno{ Id=3, Nombre="Lucía", Apellido="Castillo", Seccion="B", Ciclo="2025-1" },
            });
        }

        public IEnumerable<Alumno> Listar() => _data.ToList();

        public void Agregar(Alumno alumno)
        {
            alumno.Id = _data.Count == 0 ? 1 : _data.Max(a => a.Id) + 1;
            _data.Add(alumno);
        }
    }
}
