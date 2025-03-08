using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;

namespace DAL
{
    public class EstudianteRepository
    {
        private readonly String FileName = "Estudiante.txt";
        public EstudianteRepository() { }
        public void Guardar(Estudiante estudiante)
        {
            using (var file = new StreamWriter(FileName, true))
            {
                file.WriteLine($"{estudiante.Id};{estudiante.Nombre};{estudiante.Edad};{estudiante.Sexo};{estudiante.Promedio}");
            }
        }
        public Persona Buscar(string id)
        {
            List<Estudiante> estudiantes = ConsultarTodos();
            foreach (var item in estudiantes)
            {
                if (EsEncontrado(item, id))
                {
                    return item;
                }
            }
            return null;
        }
        public bool EsEncontrado(Estudiante estudiante, string id)
        {
            return estudiante.Id.Equals(id);
        }
        public List<Estudiante> ConsultarTodos()
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            string Linea = string.Empty;
            using (var Reader = new StreamReader(FileName))
            {
                while ((Linea = Reader.ReadLine()) != null)
                {
                    Estudiante estudiante = MapearEstudiante(Linea);
                    estudiantes.Add(estudiante);
                }
            }
            return estudiantes;
        }
        public Estudiante MapearEstudiante(string Linea)
        {
            string[] Datos = Linea.Split(';');
            Estudiante estudiante = new Estudiante();
            estudiante.Id = int.Parse(Datos[0]);
            estudiante.Nombre = Datos[1];
            estudiante.Edad = int.Parse(Datos[2]); 
            estudiante.Sexo = Datos[3][0];
            estudiante.Promedio = float.Parse(Datos[4]);
            return estudiante;
        }
        public void Eliminar(string id)
        {
            List<Estudiante> estudiantes = ConsultarTodos();
            using (var Writer = new StreamWriter(FileName))
            {
                foreach (var item in estudiantes)
                {
                    if (!EsEncontrado(item, id))
                    {
                        Writer.WriteLine($"{item.Id};{item.Nombre};{item.Edad};{item.Sexo};{item.Promedio}");
                    }
                }
            }
        }
        public void Modificar(Estudiante estudianteNuevo)
        {
            List<Estudiante> estudiantes = ConsultarTodos();
            using (var Writer = new StreamWriter(FileName))
            {
                foreach (var item in estudiantes)
                {
                    if (EsEncontrado(item, estudianteNuevo.Id.ToString()))
                    {
                        Writer.WriteLine($"{estudianteNuevo.Id};{estudianteNuevo.Nombre};{estudianteNuevo.Edad};{estudianteNuevo.Sexo};{estudianteNuevo.Promedio}");
                    }
                    else
                    {
                        Writer.WriteLine($"{item.Id};{item.Nombre};{item.Edad};{item.Sexo};{item.Promedio}");
                    }
                }
            }
        }
    }
}
