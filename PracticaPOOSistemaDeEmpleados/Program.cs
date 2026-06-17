using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaPOOSistemaDeEmpleados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Empleado> empleados = new List<Empleado>
            {
                new EmpleadoTiempoCompleto(1, "Ana López", new DateTime(2022, 3, 15), 12000m, 1500m),
                new EmpleadoPorHoras(2, "Carlos Pérez", new DateTime(2023, 7, 1), 0m, 80, 120m),
                new Gerente(3, "Lucía Ramírez", new DateTime(2020, 1, 10), 18000m, 3000m, 5)
            };

            Console.WriteLine("=== Sistema de Empleados ===\n");

            foreach (Empleado emp in empleados)
            {
                emp.MostrarInformacion();
                Console.WriteLine(new string('-', 40));
            }

            Console.ReadKey();
        }
    }
}
    

