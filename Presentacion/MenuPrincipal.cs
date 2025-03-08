using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Presentacion
{
    class MenuPrincipal
    {
        MenuGrupoDeEstudiantes menuGrupoDeEstudiantes = new MenuGrupoDeEstudiantes();
        public void ShowMenu()
        {
            Console.WriteLine("GESTOR DE GRUPOS Y ESTUDIANTES");
            Console.WriteLine("1. Gestionar estudiantes");
            Console.WriteLine("2. Gestionar Grupos de estudiantes");
            Console.WriteLine("3. Salir");
            Console.WriteLine("Seleccione una opción:");
            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":

                    break;
                case "2":
                    menuGrupoDeEstudiantes.MostrarMenu();
                    break;
                case "3":
                    Console.WriteLine("Gracias por usar la aplicación");
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }
    }
}
