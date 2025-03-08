using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;

namespace DAL
{
    public class GrupoDeEstudiantesRepository
    {
        private readonly String FileName = "GrupoDeEstudiantes.txt";
        public GrupoDeEstudiantesRepository() { }
        public void Guardar(List<GrupoDeEstudiantes> gruposDeEstudiantes)
        {
            using (var file = new StreamWriter(FileName, false)) 
            {
                foreach (var grupo in gruposDeEstudiantes)
                {
                    file.WriteLine("# Grupo");
                    file.WriteLine($"Grupo ID: {grupo.Id}; Nombre del grupo: {grupo.Nombre}");
                    foreach (var estudiante in grupo.Estudiantes)
                    {
                        file.WriteLine($"{grupo.Id};{grupo.Nombre};{estudiante.Id};{estudiante.Nombre};{estudiante.Edad};{estudiante.Sexo};{estudiante.Promedio}");
                    }
                }
            }
        }
        public void Guardar(GrupoDeEstudiantes grupoDeEstudiantes)
        {
            using (var file = new StreamWriter(FileName, true)) 
            {
                file.WriteLine("# Grupo");
                file.WriteLine($"Grupo ID: {grupoDeEstudiantes.Id}; Nombre del grupo: {grupoDeEstudiantes.Nombre}");
                foreach (var estudiante in grupoDeEstudiantes.Estudiantes)
                {
                    file.WriteLine($"{grupoDeEstudiantes.Id};{grupoDeEstudiantes.Nombre};{estudiante.Id};{estudiante.Nombre};{estudiante.Edad};{estudiante.Sexo};{estudiante.Promedio}");
                }
            }
        }
        public GrupoDeEstudiantes Buscar(int id)
        {
            List<GrupoDeEstudiantes> gruposDeEstudiantes = ConsultarTodos();
            foreach (var grupo in gruposDeEstudiantes)
            {
                if (EsEncontrado(grupo, id))
                {
                    return grupo;
                }
            }
            return null;
        }
        public bool EsEncontrado(GrupoDeEstudiantes grupoDeEstudiantes, int id)
        {
            return grupoDeEstudiantes.Id.Equals(id);
        }
        public List<GrupoDeEstudiantes> ConsultarTodos()
        {
            List<GrupoDeEstudiantes> gruposDeEstudiantes = new List<GrupoDeEstudiantes>();
            string Linea = string.Empty;
            using (var Reader = new StreamReader(FileName))
            {
                while ((Linea = Reader.ReadLine()) != null)
                {
                    if (Linea.Equals("# Grupo"))
                    {
                        GrupoDeEstudiantes grupo = MapearGrupoDeEstudiantes(Reader);
                        gruposDeEstudiantes.Add(grupo);
                    }
                }
            }
            return gruposDeEstudiantes;
        }
        public GrupoDeEstudiantes MapearGrupoDeEstudiantes(StreamReader reader)
        {
            string Linea = reader.ReadLine();
            string[] Datos = Linea.Split(';');
            GrupoDeEstudiantes grupo = new GrupoDeEstudiantes();
            grupo.Id = int.Parse(Datos[0]);
            grupo.Nombre = Datos[1];
            grupo.Estudiantes = new Estudiante[10];
            int i = 0;
            while ((Linea = reader.ReadLine()) != null)
            {
                Datos = Linea.Split(';');
                Estudiante estudiante = new Estudiante();
                estudiante.Id = int.Parse(Datos[2]);
                estudiante.Nombre = Datos[3];
                estudiante.Edad = int.Parse(Datos[4]);
                estudiante.Sexo = Datos[5][0];
                estudiante.Promedio = float.Parse(Datos[6]);
                grupo.Estudiantes[i] = estudiante;
                i++;
            }
            return grupo;
        }
        public void Eliminar(int id)
        {
            List<GrupoDeEstudiantes> gruposDeEstudiantes = ConsultarTodos();
            using (var file = new StreamWriter(FileName, false))
            {
                foreach (var grupo in gruposDeEstudiantes)
                {
                    if (!EsEncontrado(grupo, id))
                    {
                        Guardar(grupo);
                    }
                }
            }
        }
        public void Modificar(GrupoDeEstudiantes grupoDeEstudiantes)
        {
            List<GrupoDeEstudiantes> gruposDeEstudiantes = ConsultarTodos();
            using (var file = new StreamWriter(FileName, false))
            {
                foreach (var grupo in gruposDeEstudiantes)
                {
                    if (EsEncontrado(grupo, grupoDeEstudiantes.Id))
                    {
                        Guardar(grupoDeEstudiantes);
                    }
                    else
                    {
                        Guardar(grupo);
                    }
                }
            }
        }
    }
}
