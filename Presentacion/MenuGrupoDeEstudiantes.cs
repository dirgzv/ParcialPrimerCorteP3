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

        private void AgregarEstudiante(String idGrupo)
        {
            String respuesta = "s";
            do
            {
                Console.WriteLine("Ingrese el id del estudiante que desea agregar al grupo:");
                string idEstudiante = Console.ReadLine();
                //se manda el id del grupo y del estudiante a la logicaGrupo
                Console.WriteLine("Estudiante agregado correctamente");
                Console.WriteLine("Desea agregar otro estudiante al grupo? (s/n)");
                respuesta = Console.ReadLine();
            } while (respuesta.ToUpper() == "S");
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void CrearGrupo()
        {
            Console.WriteLine("Crear grupo de estudiantes");
            Console.WriteLine("Ingrese el nombre del grupo:");
            string nombreGrupo = Console.ReadLine();
            Console.WriteLine("Ingrese el id del grupo:");
            string idGrupo = Console.ReadLine();
            AgregarEstudiante(idGrupo);
            Console.WriteLine("Grupo creado correctamente");
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void ModificarGrupo()
        {
            Console.WriteLine("Modificar grupo de estudiantes");
            Console.WriteLine("Ingrese el id del grupo que desea modificar:");
            string idGrupo = Console.ReadLine();
            //se manda el id del grupo a la logicagrupo

            Console.WriteLine("Ingrese el nuevo nombre del grupo:");
            string nombreGrupoNuevo = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo id del grupo:");
            string idGrupoNuevo = Console.ReadLine();

            Console.WriteLine("Desea modificar los integrantes del grupo? (s/n)");
            string respuesta = Console.ReadLine();
            if (respuesta.ToUpper() == "S")
            {
                    AgregarEstudiante(idGrupo);
                //se manda el nombre y el id del grupo y los id de los estudiantes a la logicaGrupo
            }
            Console.WriteLine("Grupo modificado correctamente");
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void EliminarGrupo()
        {
            Console.WriteLine("Eliminar grupo de estudiantes");
            Console.WriteLine("Ingrese el id del grupo que desea eliminar:");
            string idGrupo = Console.ReadLine();
            //se manda el id del grupo a la logicagrupo
            Console.WriteLine("Grupo eliminado correctamente");
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void ListarGrupo()
        {
            Console.WriteLine("Listar grupo de estudiantes");
            //se manda a la logicaGrupo para que devuelva los grupos
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void OperacionesGrupo()
        {
            Console.WriteLine("Operaciones Grupo");
            Console.WriteLine("Ingrese el id del grupo con el que se desea realizar las operaciones:");
            string idGrupo = Console.ReadLine();
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
                    AgregarEstudiante(idGrupo);
                    break;
                case "2":
                    eliminarEstudiante(idGrupo);
                    break;
                case "3":
                    EstudianteExisteEnGrupo(idGrupo);
                    break;
                case "4":
                    GrupoExisteEnGrupo(idGrupo);
                    break;
                case "5":
                    EstudiantesComunesEngrupos(idGrupo);
                    break;
                case "6":
                    EstudiantesNoComunesEngrupos(idGrupo);
                    break;
                case "7":
                    Console.WriteLine("Volver al menú anterior");
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }
        public void eliminarEstudiante(String idGrupo)
        {
            do
            {
                Console.WriteLine("Ingrese el id del estudiante que desea eliminar del grupo:");
                string idEstudiante = Console.ReadLine();
                //se manda el id grupo y el id del estudiante a la logicaGRupo para que lo elimine del grupo
                Console.WriteLine("Estudiante eliminado correctamente");
                Console.WriteLine("Desea eliminar otro estudiante del grupo? (s/n)");
            } while (Console.ReadLine().ToUpper() == "S");
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void EstudianteExisteEnGrupo(String idGrupo)
        {
            Console.WriteLine("Ingrese el id del estudiante que desea verificar si está en el grupo:");
            string idEstudianteVerificar = Console.ReadLine();
            //se manda el id del estudiante a la logicaGrupo para que devuelva si existe o no
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void GrupoExisteEnGrupo(String idGrupo)
        {
            Console.WriteLine("Ingrese el id del grupo que desea verificar si está en el grupo:");
            string idGrupoVerificar = Console.ReadLine();
            //se manda el id del grupo  y del grupo que se desea verificaar a la logicaGrupo para que devuelva si existe o no
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void EstudiantesComunesEngrupos(String idGrupo)
        {
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
