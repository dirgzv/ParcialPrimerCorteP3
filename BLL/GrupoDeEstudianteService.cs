using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using System.IO;

namespace BLL
{
    public class GrupoDeEstudianteService
    {
        private GrupoDeEstudiantesRepository grupoDeEstudianteRepository;
        public GrupoDeEstudianteService()
        {
            grupoDeEstudianteRepository = new GrupoDeEstudiantesRepository();
        }
        public string Guardar(GrupoDeEstudiantes grupoDeEstudiante)
        {
            try
            {
                if (grupoDeEstudianteRepository.Buscar(grupoDeEstudiante.Id) == null)
                {
                    grupoDeEstudianteRepository.Guardar(grupoDeEstudiante);
                    return $"Se guardaron los datos satisfactoriamente";
                }
                return $"El estudiante con la identificación {grupoDeEstudiante.Id} ya se encuentra registrado";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicación: {e.Message}";
            }
        }
        public string Eliminar(int id)
        {
            try
            {
                if (grupoDeEstudianteRepository.Buscar(id) != null)
                {
                    grupoDeEstudianteRepository.Eliminar(id);
                    return ($"El estudiante con la identificación {id} ha sido eliminado satisfactoriamente");
                }
                return ($"El estudiante con la identificación {id} no se encuentra registrado");
            }
            catch (Exception e)
            {
                return $"Error de la Aplicación: {e.Message}";
            }
        }
        public GrupoDeEstudiantes Buscar(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El Id debe ser mayor que cero.", nameof(id));
            }
            GrupoDeEstudiantes grupoDeEstudiantes = grupoDeEstudianteRepository.Buscar(id);
            if (grupoDeEstudiantes == null)
            {
                throw new InvalidOperationException($"No se encontró un estudiante con el Id {id}.");
            }
                return grupoDeEstudiantes;
        }
        public bool EsEncontrado(GrupoDeEstudiantes grupoDeEstudiantes, int id)
        {
            if (grupoDeEstudiantes == null)
            {
                throw new ArgumentNullException(nameof(grupoDeEstudiantes), "El grupo de estudiantes no puede ser nulo.");
            }
            return grupoDeEstudianteRepository.EsEncontrado(grupoDeEstudiantes, id);
        }

        public List<GrupoDeEstudiantes> ConsultarTodos()
        {
            var grupos = grupoDeEstudianteRepository.ConsultarTodos();
            if (grupos == null || grupos.Count == 0)
            {
                throw new Exception("No hay grupos de estudiantes registrados.");
            }
            return grupos;
        }

        public GrupoDeEstudiantes MapearGrupoDeEstudiantes(StreamReader reader)
        {
            var grupo = grupoDeEstudianteRepository.MapearGrupoDeEstudiantes(reader);

            if (grupo == null)
            {
                throw new Exception("El mapeo no se pudo realizar correctamente.");
            }
            return grupo;
        }

        public string Modificar(GrupoDeEstudiantes grupoDeEstudiantes)
        {
            try
            {
                if (grupoDeEstudianteRepository.Buscar(grupoDeEstudiantes.Id) != null)
                {
                    grupoDeEstudianteRepository.Modificar(grupoDeEstudiantes);
                    return ($"El estudiante con la identificación {grupoDeEstudiantes.Id} ha sido modificado satisfactoriamente");
                }
                return ($"El estudiante con la identificación {grupoDeEstudiantes.Id} no se encuentra registrado");
            }
            catch (Exception e)
            {
                return $"Error de la Aplicación: {e.Message}";
            }
        }
        public String AgregarEstudiante(GrupoDeEstudiantes grupoDeEstudiantes, int id)
        {
            if (grupoDeEstudiantes == null)
            {
                throw new ArgumentNullException(nameof(grupoDeEstudiantes), "El grupo de estudiantes no puede ser nulo.");
            }

            if (id <= 0)
            {
                throw new ArgumentException("El ID debe ser mayor que cero.", nameof(id));
            }
            EstudianteRepository estudianteRepository = new EstudianteRepository();
            Estudiante estudiante = estudianteRepository.Buscar(id);

            if (estudiante == null)
            {
                throw new InvalidOperationException($"No se encontró un estudiante con el ID {id}.");
            }
            grupoDeEstudianteRepository.AgregarEstudiante(grupoDeEstudiantes, estudiante);
            return ($"El estudiante con la identificación {grupoDeEstudiantes.Id} se encuentra agregado");

        }
        public void ListarGrupo(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID debe ser mayor que cero.", nameof(id));
            }
            GrupoDeEstudiantes grupoDeEstudiantes = grupoDeEstudianteRepository.Buscar(id);
            if (grupoDeEstudiantes == null)
            {
                throw new InvalidOperationException($"No se encontró un grupo de estudiantes con el ID {id}.");
            }
            Console.WriteLine($"Grupo ID: {grupoDeEstudiantes.Id}; Nombre del grupo: {grupoDeEstudiantes.Nombre}");
            foreach (var estudiante in grupoDeEstudiantes.Estudiantes)
            {
                Console.WriteLine($"{grupoDeEstudiantes.Id};{grupoDeEstudiantes.Nombre};{estudiante.Id};{estudiante.Nombre};{estudiante.Edad};{estudiante.Sexo};{estudiante.Promedio}");
            }
        }
        public String EliminarEstudiante(GrupoDeEstudiantes grupoDeEstudiantes,int id)
        {
            if (grupoDeEstudiantes == null)
            {
                throw new ArgumentNullException(nameof(grupoDeEstudiantes), "El grupo de estudiantes no puede ser nulo.");
            }
            if (id <= 0)
            {
                throw new ArgumentException("El ID debe ser mayor que cero.", nameof(id));
            }
            EstudianteRepository estudianteRepository = new EstudianteRepository();
            Estudiante estudiante = estudianteRepository.Buscar(id);
            if (estudiante == null)
            {
                throw new InvalidOperationException($"No se encontró un estudiante con el ID {id}.");
            }
            grupoDeEstudianteRepository.EliminarEstudiante(grupoDeEstudiantes, estudiante);
            return ($"El estudiante con la identificación {grupoDeEstudiantes.Id} se encuentra eliminado");
        }
        public String ExisteEnGrupo(GrupoDeEstudiantes grupoDeEstudiantes,int id)
        {
            if (grupoDeEstudiantes == null)
            {
                throw new ArgumentNullException(nameof(grupoDeEstudiantes), "El grupo de estudiantes no puede ser nulo.");
            }
            if (id <= 0)
            {
                throw new ArgumentException("El ID debe ser mayor que cero.", nameof(id));
            }
            EstudianteRepository estudianteRepository = new EstudianteRepository();
            Estudiante estudiante = estudianteRepository.Buscar(id);
            if (estudiante == null)
            {
                throw new ArgumentNullException(nameof(estudiante), "El estudiante no puede ser nulo.");
            }
            if (grupoDeEstudianteRepository.ExisteEnGrupo(grupoDeEstudiantes, estudiante))
            {
                return ($"El estudiante con la identificación {grupoDeEstudiantes.Id} se encuentra en el grupo");
            }
            return ($"El estudiante con la identificación {grupoDeEstudiantes.Id} no se encuentra en el grupo");
        }
        public String ExisteEnGrupo(GrupoDeEstudiantes grupoDeEstudiantes, GrupoDeEstudiantes grupoDeEstudiantesVerificar)
        {
            if (grupoDeEstudiantes == null)
            {
                throw new ArgumentNullException(nameof(grupoDeEstudiantes), "El grupo de estudiantes no puede ser nulo.");
            }
            if (grupoDeEstudiantesVerificar == null)
            {
                throw new ArgumentNullException(nameof(grupoDeEstudiantesVerificar), "El grupo de estudiantes a verificar no puede ser nulo.");
            }
            if (grupoDeEstudianteRepository.ExisteEnGrupo(grupoDeEstudiantes, grupoDeEstudiantesVerificar))
            {
                return ($"El grupo con la identificación {grupoDeEstudiantes.Id} se encuentra en el grupo");
            }
            return ($"El grupo con la identificación {grupoDeEstudiantes.Id} no se encuentra en el grupo");
        }
    }
}
