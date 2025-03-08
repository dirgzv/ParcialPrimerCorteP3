using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    class MenuEstudiantes
    {
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("1. Agregar Estudiante");
            Console.WriteLine("2. Modificar Estudiante");
            Console.WriteLine("3. Eliminar Estudiante");
            Console.WriteLine("4. Listar Estudiantes");
            Console.WriteLine("5. Buscar Estudiante");
            Console.WriteLine("6. Regresar");
            Console.WriteLine("Digite una opción: ");
            String opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    AgregarEstudiante();
                    break;
                case "2":
                    ModificarEstudiante();
                    break;
                case "3":
                    EliminarEstudiante();
                    break;
                case "4":
                    ListarEstudiantes();
                    break;
                case "5":
                    BuscarEstudiante();
                    break;
                case "6":
                    Console.WriteLine("Regresando al menú principal");
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }
        public void AgregarEstudiante()
        {
            do
            {
                Console.WriteLine("Ingrese el id del estudiante:");
                String idEstudiante = Console.ReadLine();
                Console.WriteLine("Ingrese el nombre del estudiante:");
                String nombreEstudiante = Console.ReadLine();
                Console.WriteLine("Ingrese el apellido del estudiante:");
                String apellidoEstudiante = Console.ReadLine();
                Console.WriteLine("Ingrese la edad del estudiante:");
                String edadEstudiante = Console.ReadLine();
                Console.WriteLine("Ingrese el sexo del estudiante:");
                char sexoEstudiante = char.Parse(Console.ReadLine());
                Console.WriteLine("digite la nota del primer parcial:");
                double primerParcial = double.Parse(Console.ReadLine());
                Console.WriteLine("digite la nota del segundo parcial:");
                double segundoParcial = double.Parse(Console.ReadLine());
                Console.WriteLine("digite la nota del tercer parcial:");
                double tercerParcial = double.Parse(Console.ReadLine());
                //se manda los datos del estudiante a la logicaEstudiante para que se agregue
                Console.WriteLine("Estudiante agregado correctamente");
                Console.WriteLine("Desea agregar otro estudiante? (s/n)");
            } while (Console.ReadLine().ToUpper() == "S");
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void ModificarEstudiante()
        {
            Console.WriteLine("Ingrese el id del estudiante que desea modificar:");
            String idEstudiante = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo nombre del estudiante:");
            String nombreEstudiante = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo apellido del estudiante:");
            String apellidoEstudiante = Console.ReadLine();
            Console.WriteLine("Ingrese la nueva edad del estudiante:");
            String edadEstudiante = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo sexo del estudiante:");
            char sexoEstudiante = char.Parse(Console.ReadLine());
            Console.WriteLine("digite la nueva nota del primer parcial:");
            double primerParcial = double.Parse(Console.ReadLine());
            Console.WriteLine("digite la nueva nota del segundo parcial:");
            double segundoParcial = double.Parse(Console.ReadLine());
            Console.WriteLine("digite la nueva nota del tercer parcial:");
            double tercerParcial = double.Parse(Console.ReadLine());
            //se manda los datos del estudiante a la logicaEstudiante para que se modifique
            Console.WriteLine("Estudiante modificado correctamente");
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void EliminarEstudiante()
        {
            Console.WriteLine("Ingrese el id del estudiante que desea eliminar:");
            String idEstudiante = Console.ReadLine();
            //se manda el id del estudiante a la logicaEstudiante para que se elimine
            Console.WriteLine("Estudiante eliminado correctamente");
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void ListarEstudiantes()
        {
            //se pide a la logicaEstudiante que devuelva la lista de estudiantes
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void BuscarEstudiante()
        {
            Console.WriteLine("Ingrese el id del estudiante que desea buscar:");
            String idEstudiante = Console.ReadLine();
            //se manda el id del estudiante a la logicaEstudiante para que se busque  y devuelva los datos
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
    }
}