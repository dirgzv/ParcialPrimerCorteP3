using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Entity;
namespace Presentacion
{
    class MenuGrupoDeEstudiantes
    {
        public GrupoDeEstudianteService grupoDeEstudianteService = new GrupoDeEstudianteService();
        public void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Crear grupo de estudiantes");
            Console.WriteLine("2. Modificar grupo de estudiantes");
            Console.WriteLine("3. Eliminar grupo de estudiantes");
            Console.WriteLine("4. Listar grupo de estudiantes");
            Console.WriteLine("5. Operaciones Grupo");
            Console.WriteLine("6. Volver al menú principal");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    CrearGrupo();
                    break;
                case "2":
                    ModificarGrupo();
                    break;
                case "3":
                    EliminarGrupo();
                    break;
                case "4":
                    ListarGrupo();
                    break;
                case "5":
                    OperacionesGrupo();
                    break;
                case "6":
                    Console.WriteLine("Volver al menú principal");
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }

        private GrupoDeEstudiantes AgregarEstudiante(GrupoDeEstudiantes grupoDeEstudiantes)
        {
            String respuesta = "s";
            do
            {
                Console.WriteLine("Ingrese el id del estudiante que desea agregar al grupo:");
                string idEstudiante = Console.ReadLine();
                Console.WriteLine(grupoDeEstudianteService.AgregarEstudiante(grupoDeEstudiantes, int.Parse(idEstudiante)));
                Console.WriteLine("Desea agregar otro estudiante al grupo? (s/n)");
                respuesta = Console.ReadLine();
            } while (respuesta.ToUpper() == "S");
            return grupoDeEstudiantes;
        }
        public void CrearGrupo()
        {
            GrupoDeEstudiantes grupoDeEstudiantes = new GrupoDeEstudiantes();
            Console.WriteLine("Crear grupo de estudiantes");
            Console.WriteLine("Ingrese el nombre del grupo:");
            grupoDeEstudiantes.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el id del grupo:");
            grupoDeEstudiantes.Id = int.Parse(Console.ReadLine());
            grupoDeEstudiantes = AgregarEstudiante(grupoDeEstudiantes);
            Console.WriteLine(grupoDeEstudianteService.Guardar(grupoDeEstudiantes));
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void ModificarGrupo()
        {
            Console.WriteLine("Modificar grupo de estudiantes");
            Console.WriteLine("Ingrese el id del grupo que desea modificar:");
            string idGrupo = Console.ReadLine();
            GrupoDeEstudiantes grupoDeEstudiantes = grupoDeEstudianteService.Buscar(int.Parse(idGrupo));
            Console.WriteLine("Ingrese el nuevo nombre del grupo:");
            grupoDeEstudiantes.Nombre = Console.ReadLine();
            Console.WriteLine("Desea modificar los integrantes del grupo? (s/n)");
            string respuesta = Console.ReadLine();
            if (respuesta.ToUpper() == "S")
            {
                if (grupoDeEstudiantes.Estudiantes.Count > 0)
                {
                    grupoDeEstudiantes.Estudiantes.Clear();
                }
                grupoDeEstudiantes = AgregarEstudiante(grupoDeEstudiantes);
                Console.WriteLine(grupoDeEstudianteService.Modificar(grupoDeEstudiantes));
            }
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void EliminarGrupo()
        {
            Console.WriteLine("Eliminar grupo de estudiantes");
            Console.WriteLine("Ingrese el id del grupo que desea eliminar:");
            string idGrupo = Console.ReadLine();
            Console.WriteLine(grupoDeEstudianteService.Eliminar(int.Parse(idGrupo)));
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void ListarGrupo()
        {
            Console.WriteLine("Listar grupo de estudiantes");
            Console.WriteLine("Ingrese el id del grupo que desea listar:");
            string idGrupo = Console.ReadLine();
            grupoDeEstudianteService.ListarGrupo(int.Parse(idGrupo));
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void OperacionesGrupo()
        {
            Console.WriteLine("Operaciones Grupo");
            Console.WriteLine("Ingrese el id del grupo con el que se desea realizar las operaciones:");
            string idGrupo = Console.ReadLine();
            GrupoDeEstudiantes grupoDeEstudiantes= grupoDeEstudianteService.Buscar(int.Parse(idGrupo));
            Console.WriteLine("1. Agregar estudiante");
            Console.WriteLine("2. Eliminar estudiante");
            Console.WriteLine("3. verificacion de existencia de estudiante en un grupo");
            Console.WriteLine("4. verificacion de existencia de un grupo de estudiantes en un grupo");
            Console.WriteLine("5. mostrar Estudiantes comunes de dos grupos");
            Console.WriteLine("6. mostrar Estudiantes de un grupo que no esten en otro grupo");
            Console.WriteLine("7. Volver al menú anterior");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarEstudiante(grupoDeEstudiantes);
                    break;
                case "2":
                    eliminarEstudiante(grupoDeEstudiantes);
                    break;
                case "3":
                    EstudianteExisteEnGrupo(grupoDeEstudiantes);
                    break;
                case "4":
                    GrupoExisteEnGrupo(grupoDeEstudiantes);
                    break;
                case "5":
                    EstudiantesComunesEngrupos(grupoDeEstudiantes);
                    break;
                case "6":
                    EstudiantesNoComunesEngrupos(grupoDeEstudiantes);
                    break;
                case "7":
                    Console.WriteLine("Volver al menú anterior");
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }
        public void eliminarEstudiante(GrupoDeEstudiantes grupoDeEstudiantes)
        {
            do
            {
                Console.WriteLine("Ingrese el id del estudiante que desea eliminar del grupo:");
                string idEstudiante = Console.ReadLine();
                Console.WriteLine(grupoDeEstudianteService.EliminarEstudiante(grupoDeEstudiantes, int.Parse(idEstudiante)));
                Console.WriteLine("Desea eliminar otro estudiante del grupo? (s/n)");
            } while (Console.ReadLine().ToUpper() == "S");
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void EstudianteExisteEnGrupo(GrupoDeEstudiantes grupoDeEstudiantes)
        {
            Console.WriteLine("Ingrese el id del estudiante que desea verificar si está en el grupo:");
            string idEstudianteVerificar = Console.ReadLine();
            Console.WriteLine(grupoDeEstudianteService.ExisteEnGrupo(grupoDeEstudiantes, int.Parse(idEstudianteVerificar)));
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void GrupoExisteEnGrupo(GrupoDeEstudiantes grupoDeEstudiantes)
        {
            Console.WriteLine("Ingrese el id del grupo que desea verificar si está en el grupo:");
            string idGrupoVerificar = Console.ReadLine();
            GrupoDeEstudiantes grupoDeEstudiantesVerificar = grupoDeEstudianteService.Buscar(int.Parse(idGrupoVerificar));
            if (grupoDeEstudiantesVerificar == null)
            {
                Console.WriteLine("El grupo que desea buscar en otro grupo no existe");
            }
            else
            {
                Console.WriteLine(grupoDeEstudianteService.ExisteEnGrupo(grupoDeEstudiantes, grupoDeEstudiantesVerificar));
            }
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void EstudiantesComunesEngrupos(GrupoDeEstudiantes grupoDeEstudiantes)
        {
            //por aqui vamos
            Console.WriteLine("Ingrese el id del segundo grupo:");
            string idGrupo2 = Console.ReadLine();
            //se manda los id de los grupos a la logicaGrupo para que devuelva los estudiantes comunes
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void EstudiantesNoComunesEngrupos(String idGrupo)
        {
            Console.WriteLine("Ingrese el id del segundo grupo:");
            string idGrupo2 = Console.ReadLine();
            //se manda los id de los grupos a la logicaGrupo para que devuelva los estudiantes que no estan en el otro grupo
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
    }
}
