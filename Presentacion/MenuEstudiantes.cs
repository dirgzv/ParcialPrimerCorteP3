using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Entity;
namespace Presentacion
{
    class MenuEstudiantes
    {
        public EstudianteService estudianteService = new EstudianteService();
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
                Estudiante estudiante = new Estudiante();
                Console.WriteLine("Ingrese el id del estudiante:");
                estudiante.Id = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el nombre del estudiante:");
                estudiante.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el apellido del estudiante:");
                estudiante.Apellido = Console.ReadLine();
                Console.WriteLine("Ingrese la edad del estudiante:");
                estudiante.Edad = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el sexo del estudiante:");
                estudiante.Sexo = char.ToUpper(char.Parse(Console.ReadLine()));
                Console.WriteLine("digite la nota del primer parcial:");
                estudiante.PrimerParcial = float.Parse(Console.ReadLine());
                Console.WriteLine("digite la nota del segundo parcial:");
                estudiante.SegundoParcial = float.Parse(Console.ReadLine());
                Console.WriteLine("digite la nota del tercer parcial:");
                estudiante.TercerParcial = float.Parse(Console.ReadLine());
                estudianteService.CalcularPromedio(estudiante);
                estudianteService.Guardar(estudiante);
                Console.WriteLine("Estudiante agregado correctamente");
                Console.WriteLine("Desea agregar otro estudiante? (s/n)");
            } while (Console.ReadLine().ToUpper() == "S");
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void ModificarEstudiante()
        {
            Estudiante estudiante = new Estudiante();
            Console.WriteLine("Ingrese el id del estudiante que desea modificar:");
            estudiante.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo nombre del estudiante:");
            estudiante.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo apellido del estudiante:");
            estudiante.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese la nueva edad del estudiante:");
            estudiante.Edad = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo sexo del estudiante:");
            estudiante.Sexo = char.ToUpper(char.Parse(Console.ReadLine()));
            Console.WriteLine("digite la nueva nota del primer parcial:");
            estudiante.PrimerParcial = float.Parse(Console.ReadLine());
            Console.WriteLine("digite la nueva nota del segundo parcial:");
            estudiante.SegundoParcial = float.Parse(Console.ReadLine());
            Console.WriteLine("digite la nueva nota del tercer parcial:");
            estudiante.TercerParcial = float.Parse(Console.ReadLine());
            estudianteService.CalcularPromedio(estudiante);
            estudianteService.Modificar(estudiante);
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void EliminarEstudiante()
        {
            Console.WriteLine("Ingrese el id del estudiante que desea eliminar:");
            String idEstudiante = Console.ReadLine();
            estudianteService.Eliminar(int.Parse(idEstudiante));
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void ListarEstudiantes()
        {
            List<Estudiante> estudiantes = estudianteService.ConsultarTodos();
            foreach (var item in estudiantes)
            {
                Console.WriteLine($"Id: {item.Id}");
                Console.WriteLine($"Nombre: {item.Nombre}");
                Console.WriteLine($"Apellido: {item.Apellido}");
                Console.WriteLine($"Edad: {item.Edad}");
                Console.WriteLine($"Sexo: {item.Sexo}");
                Console.WriteLine($"Primer Parcial: {item.PrimerParcial}");
                Console.WriteLine($"Segundo Parcial: {item.SegundoParcial}");
                Console.WriteLine($"Tercer Parcial: {item.TercerParcial}");
                Console.WriteLine($"Promedio: {item.Promedio}");
                Console.WriteLine("-------------------------------------------------");
            }
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void BuscarEstudiante()
        {
            Console.WriteLine("Ingrese el id del estudiante que desea buscar:");
            String idEstudiante = Console.ReadLine();
            Estudiante estudiante = estudianteService.Buscar(int.Parse(idEstudiante));
            if (estudiante != null)
            {
                Console.WriteLine($"Id: {estudiante.Id}");
                Console.WriteLine($"Nombre: {estudiante.Nombre}");
                Console.WriteLine($"Apellido: {estudiante.Apellido}");
                Console.WriteLine($"Edad: {estudiante.Edad}");
                Console.WriteLine($"Sexo: {estudiante.Sexo}");
                Console.WriteLine($"Primer Parcial: {estudiante.PrimerParcial}");
                Console.WriteLine($"Segundo Parcial: {estudiante.SegundoParcial}");
                Console.WriteLine($"Tercer Parcial: {estudiante.TercerParcial}");
                Console.WriteLine($"Promedio: {estudiante.Promedio}");
            }
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
    }
}