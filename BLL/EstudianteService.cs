using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class EstudianteService
    {
        private EstudianteRepository estudianteRepository;
        public EstudianteService()
        {
            estudianteRepository = new EstudianteRepository();
        }
        public string Guardar(Estudiante estudiante)
        {
            try
            {
                if (estudianteRepository.Buscar(estudiante.Id) == null)
                {
                    estudianteRepository.Guardar(estudiante);
                    return $"Se guardaron los datos satisfactoriamente";
                }
                return $"El estudiante con la identificación {estudiante.Id} ya se encuentra registrado";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicación al intentar guardar el estudiante: {e.Message}";
            }
        }
        public string Eliminar(int id)
        {
            try
            {
                if (estudianteRepository.Buscar(id) != null)
                {
                    estudianteRepository.Eliminar(id);
                    return ($"El estudiante con la identificación {id} ha sido eliminado satisfactoriamente");
                }
                return ($"El estudiante con la identificación {id} no se encuentra registrado");
            }
            catch (Exception e)
            {
                return $"Error de la Aplicación al intentar eliminar al estudiante: {e.Message}";
            }
        }
        public Estudiante Buscar(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El Id debe ser mayor que cero.", nameof(id));
            }
            var estudiante = estudianteRepository.Buscar(id);
            if (estudiante == null)
            {
                throw new InvalidOperationException($"No se encontró un estudiante con el Id {id}.");
            }
            return estudiante;
        }

        public Estudiante CalcularPromedio(Estudiante estudiante)
        {
            if (estudiante == null)
            {
                throw new ArgumentNullException(nameof(estudiante), "Error al calcular promedio,El objeto estudiante no puede ser nulo.");
            }
            estudiante.CalcularPromedio(); 
            return estudiante; 
        }
        public String Modificar(Estudiante estudiante)
        {
            try
            {
                if (estudianteRepository.Buscar(estudiante.Id) != null)
                {
                    estudianteRepository.Modificar(estudiante);
                    return ($"El estudiante con la identificación {estudiante.Id} ha sido modificado satisfactoriamente");
                }
                return ($"El estudiante con la identificación {estudiante.Id} no se encuentra registrado");
            }
            catch (Exception e)
            {
                return $"Error de la Aplicación al intentar modificar el estudiante: {e.Message}";
            }
        }
        public List<Estudiante> ConsultarTodos()
        {
            return estudianteRepository.ConsultarTodos();
        }
    }
}
