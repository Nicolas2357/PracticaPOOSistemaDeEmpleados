using PracticaPOOSistemaDeEmpleados.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaPOOSistemaDeEmpleados
{
    internal class Program
    {
        static List<Empleado> empleados = new List<Empleado>();
        static int siguienteId = 1;

        static void Main(string[] args)
        {
            CargarEmpleadosDeEjemplo();

            bool salir = false;
            while (!salir)
            {
                MostrarMenu();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ListarEmpleados();
                        break;
                    case "2":
                        AgregarEmpleado();
                        break;
                    case "3":
                        EliminarEmpleado();
                        break;
                    case "4":
                        MostrarReportesDesempeno();
                        break;
                    case "0":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresiona una tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void CargarEmpleadosDeEjemplo()
        {
            empleados.Add(new EmpleadoTiempoCompleto(siguienteId++, "Ana López", new DateTime(2022, 3, 15), 12000m, 1500m));
            empleados.Add(new EmpleadoPorHoras(siguienteId++, "Carlos Pérez", new DateTime(2023, 7, 1), 0m, 80, 120m));
            empleados.Add(new Gerente(siguienteId++, "Lucía Ramírez", new DateTime(2020, 1, 10), 18000m, 3000m, 5));
        }

        static void MostrarMenu()
        {
            Console.WriteLine("=== Sistema de Empleados ===");
            Console.WriteLine("1. Listar empleados");
            Console.WriteLine("2. Agregar empleado");
            Console.WriteLine("3. Eliminar empleado");
            Console.WriteLine("4. Ver reportes de desempeño (polimorfismo)");
            Console.WriteLine("0. Salir");
            Console.Write("Selecciona una opción: ");
        }

        static void ListarEmpleados()
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                return;
            }

            foreach (Empleado emp in empleados)
            {
                emp.MostrarInformacion();
                Console.WriteLine(new string('-', 40));
            }
        }

        static void AgregarEmpleado()
        {
            Console.WriteLine("Tipo de empleado:");
            Console.WriteLine("1. Tiempo completo");
            Console.WriteLine("2. Por horas");
            Console.WriteLine("3. Gerente");
            Console.Write("Selecciona el tipo: ");
            string tipo = Console.ReadLine();

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Salario base: ");
            decimal salarioBase = decimal.Parse(Console.ReadLine());

            switch (tipo)
            {
                case "1":
                    Console.Write("Bono mensual: ");
                    decimal bono = decimal.Parse(Console.ReadLine());
                    empleados.Add(new EmpleadoTiempoCompleto(siguienteId++, nombre, DateTime.Now, salarioBase, bono));
                    break;

                case "2":
                    Console.Write("Horas trabajadas: ");
                    int horas = int.Parse(Console.ReadLine());
                    Console.Write("Tarifa por hora: ");
                    decimal tarifa = decimal.Parse(Console.ReadLine());
                    empleados.Add(new EmpleadoPorHoras(siguienteId++, nombre, DateTime.Now, salarioBase, horas, tarifa));
                    break;

                case "3":
                    Console.Write("Bono por desempeño: ");
                    decimal bonoDesempeno = decimal.Parse(Console.ReadLine());
                    Console.Write("Cantidad de empleados a cargo: ");
                    int cantidad = int.Parse(Console.ReadLine());
                    empleados.Add(new Gerente(siguienteId++, nombre, DateTime.Now, salarioBase, bonoDesempeno, cantidad));
                    break;

                default:
                    Console.WriteLine("Tipo no válido. No se agregó el empleado.");
                    return;
            }

            Console.WriteLine("Empleado agregado correctamente.");
        }

        static void EliminarEmpleado()
        {
            Console.Write("Ingresa el ID del empleado a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID no válido.");
                return;
            }

            Empleado empleado = empleados.FirstOrDefault(e => e.Id == id);
            if (empleado == null)
            {
                Console.WriteLine("No se encontró un empleado con ese ID.");
                return;
            }

            empleados.Remove(empleado);
            Console.WriteLine("Empleado eliminado correctamente.");
        }

        static void MostrarReportesDesempeno()
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                return;
            }

            Console.WriteLine("=== Reportes de desempeño ===\n");

            foreach (IEvaluable evaluable in empleados.OfType<IEvaluable>())
            {
                Console.WriteLine(evaluable.GenerarReporteDesempeño());
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}
    

