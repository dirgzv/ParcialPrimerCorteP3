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

            return grupoDeEstudianteRepository.Buscar(id);
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
    }
}
