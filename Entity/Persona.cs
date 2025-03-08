using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public char Sexo { get; set; }

        public Persona() { }

        public Persona(int id, string nombre, string apellido, int edad, char sexo)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Sexo = sexo;
        }
    }
}
