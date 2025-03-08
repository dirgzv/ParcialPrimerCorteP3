using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    class Estudiante : Persona
    {
        public float PrimerParcial { get; set; }
        public float SegundoParcial { get; set; }
        public float TercerParcial { get; set; }

        public float Promedio { get; set; }

        public Estudiante() { }

        public Estudiante(int id, string nombre, string apellido, int edad, char sexo, float primerParcial, float segundoParcial, float tercerParcial)
            : base(id, nombre, apellido, edad, sexo)
        {
            PrimerParcial = primerParcial;
            SegundoParcial = segundoParcial;
            TercerParcial = tercerParcial;
            Promedio = (PrimerParcial + SegundoParcial + TercerParcial) / 3;
        }
    }
}
