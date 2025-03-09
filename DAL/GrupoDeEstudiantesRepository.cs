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
            string Linea = string.Empty;
            Linea = reader.ReadLine();
            string[] DatosGrupo = Linea.Split(';');
            GrupoDeEstudiantes grupo = new GrupoDeEstudiantes();
            grupo.Id = int.Parse(DatosGrupo[0].Split(':')[1]);
            grupo.Nombre = DatosGrupo[1].Split(':')[1];
            while ((Linea = reader.ReadLine()) != null)
            {
                string[] DatosEstudiante = Linea.Split(';');
                Estudiante estudiante = new Estudiante();
                estudiante.Id = int.Parse(DatosEstudiante[2]);
                estudiante.Nombre = DatosEstudiante[3];
                estudiante.Edad = int.Parse(DatosEstudiante[4]);
                estudiante.Sexo = char.Parse(DatosEstudiante[5]);
                estudiante.Promedio = float.Parse(DatosEstudiante[6]);
                grupo.AgregarEstudiante(estudiante);
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
        public void AgregarEstudiante(GrupoDeEstudiantes grupoDeEstudiantes, Estudiante estudiante)
        {
                grupoDeEstudiantes.AgregarEstudiante(estudiante);
        }
        public GrupoDeEstudiantes ListarGrupo(int id) {
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
        public void EliminarEstudiante(GrupoDeEstudiantes grupoDeEstudiantes, Estudiante estudiante)
        {
            grupoDeEstudiantes.Estudiantes.Remove(estudiante);
        }
        public bool ExisteEnGrupo(GrupoDeEstudiantes grupoDeEstudiantes, Estudiante estudiante)
        {
            return grupoDeEstudiantes.Estudiantes.Contains(estudiante);
        }
        public bool ExisteEnGrupo(GrupoDeEstudiantes grupoDeEstudiantes, GrupoDeEstudiantes grupo)
        {
            foreach (var estudiante in grupo.Estudiantes)
            {
                if (!ExisteEnGrupo(grupoDeEstudiantes, estudiante))
                {
                    return false;
                }
            }
            return true;
        }
        public GrupoDeEstudiantes EstudiantesComunesEngrupos(GrupoDeEstudiantes grupoDeEstudiantes, GrupoDeEstudiantes grupoDeEstudiantesVerificar)
        {
            GrupoDeEstudiantes grupo = CrearGrupoResultante(grupoDeEstudiantes, grupoDeEstudiantesVerificar, "interseccion");
            foreach (var estudiante in grupoDeEstudiantes.Estudiantes)
            {
                if (ExisteEnGrupo(grupoDeEstudiantesVerificar, estudiante))
                {
                    grupo.AgregarEstudiante(estudiante);
                }
            }
            if (grupo.Estudiantes.Count == 0)
            {
                return null;
            }
            return grupo;
        }
        public bool idsExistentes(int id)
        {
            List<GrupoDeEstudiantes> gruposDeEstudiantes = ConsultarTodos();
            foreach (var grupo in gruposDeEstudiantes)
            {
                if (grupo.Id == id)
                {
                    return true;
                }
            }
            return false;
        }
        public GrupoDeEstudiantes CrearGrupoResultante(GrupoDeEstudiantes grupoDeEstudiantes, GrupoDeEstudiantes grupoDeEstudiantesVerificar, String opcion)
        {
            GrupoDeEstudiantes grupo = new GrupoDeEstudiantes();
            int nuevoId;
            Random random = new Random();
            do
            {
                nuevoId = random.Next(1, int.MaxValue);
            } while (idsExistentes(nuevoId));
            grupo.Id = nuevoId;
            grupo.Nombre = grupoDeEstudiantes.Nombre + " ∩ " + grupoDeEstudiantesVerificar.Nombre;

            switch (opcion)
            {
                case "union":
                    grupo.Nombre = grupoDeEstudiantes.Nombre + " ∪ " + grupoDeEstudiantesVerificar.Nombre;
                    break;
                case "interseccion":
                    grupo.Nombre = grupoDeEstudiantes.Nombre + " ∩ " + grupoDeEstudiantesVerificar.Nombre;
                    break;
                case "diferencia":
                    grupo.Nombre = grupoDeEstudiantes.Nombre + " - " + grupoDeEstudiantesVerificar.Nombre;
                    break;
                default:
                    break;
            }
            return grupo;
        }
        public GrupoDeEstudiantes EstudiantesNoComunesEngrupos(GrupoDeEstudiantes grupoDeEstudiantes, GrupoDeEstudiantes grupoDeEstudiantesVerificar)
        {
            GrupoDeEstudiantes grupo= CrearGrupoResultante(grupoDeEstudiantes, grupoDeEstudiantesVerificar, "diferencia");
            foreach (var estudiante in grupoDeEstudiantes.Estudiantes)
            {
                if (!ExisteEnGrupo(grupoDeEstudiantesVerificar, estudiante))
                {
                    grupo.AgregarEstudiante(estudiante);
                }
            }
            foreach (var estudiante in grupoDeEstudiantesVerificar.Estudiantes)
            {
                if (!ExisteEnGrupo(grupoDeEstudiantes, estudiante))
                {
                    grupo.AgregarEstudiante(estudiante);
                }
            }
            if (grupo.Estudiantes.Count == 0)
            {
                return null;
            }
            return grupo;
        }
        public GrupoDeEstudiantes UnionDeGrupos(GrupoDeEstudiantes grupoDeEstudiantes, GrupoDeEstudiantes grupoDeEstudiantesVerificar)
        {
            GrupoDeEstudiantes grupo = CrearGrupoResultante(grupoDeEstudiantes, grupoDeEstudiantesVerificar, "union");
            foreach (var estudiante in grupoDeEstudiantes.Estudiantes)
            {
                grupo.AgregarEstudiante(estudiante);
            }
            foreach (var estudiante in grupoDeEstudiantesVerificar.Estudiantes)
            {
                grupo.AgregarEstudiante(estudiante);
            }
            if (grupo.Estudiantes.Count == 0)
            {
                return null;
            }
            return grupo;
        }
    }
}
