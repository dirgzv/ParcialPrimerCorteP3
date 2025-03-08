using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class GrupoDeEstudiantes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Estudiante> Estudiantes { get; set; }

        public GrupoDeEstudiantes() {
            Estudiantes = new List<Estudiante>();
        }
        public GrupoDeEstudiantes(int id, string nombre, List<Estudiante> estudiantes )
        {
            Id = id;
            Nombre = nombre;
            Estudiantes = estudiantes;
        }
        public void AgregarEstudiante(Estudiante estudiante)
        {
            Estudiantes.Add(estudiante);
        }
    }
}
