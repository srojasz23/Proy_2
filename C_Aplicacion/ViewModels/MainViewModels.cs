using Datos;
using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace C_Aplicacion.ViewModels
{
    public class MainViewModels : BaseViewModels
    {
        private readonly AlumnoServicio _servicio;
        public ObservableCollection<Alumno> Alumnos { get; } = new();

        private string _nombre = string.Empty;
        public string Nombre
        {
            get => _nombre;
            set { _nombre = value; OnPropertyChanged(); }
        }

        private string _apellido = string.Empty;
        public string Apellido
        {
            get => _apellido;
            set { _apellido = value; OnPropertyChanged(); }
        }

        public MainViewModels()
        {
            var repo = new AlumnoRepositorioMemoria();
            _servicio = new AlumnoServicio(repo);
            Cargar();
        }

        public void Cargar()
        {
            Alumnos.Clear();
            foreach (var a in _servicio.Listar()) Alumnos.Add(a);
        }

        public void Agregar()
        {

            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Apellido))
                return;

            var nuevo = new Alumno
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Seccion = "A",
                Ciclo = "2025-1"
            };


            _servicio.Agregar(nuevo);


            Alumnos.Add(nuevo);


            Nombre = string.Empty;
            Apellido = string.Empty;

            MessageBox.Show("Alumno agregado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}