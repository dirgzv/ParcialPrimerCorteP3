using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    class GrupoDeEstudiantes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Estudiante[] Estudiantes { get; set; }

        public GrupoDeEstudiantes() { }

        public GrupoDeEstudiantes(int id, string nombre, Estudiante[] estudiantes)
        {
            Id = id;
            Nombre = nombre;
            Estudiantes = estudiantes;
        }
    }
}
