using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaPOOSistemaDeEmpleados
{
    public abstract class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaContratacion { get; set; }
        public decimal SalarioBase { get; set; }

        protected Empleado(int id, string nombre, DateTime fechaContratacion, decimal salarioBase)
        {
            Id = id;
            Nombre = nombre;
            FechaContratacion = fechaContratacion;
            SalarioBase = salarioBase;
        }

        public abstract decimal CalcularPago();

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Fecha de contratación: {FechaContratacion.ToShortDateString()}");
            Console.WriteLine($"Salario base: {SalarioBase:C}");
            Console.WriteLine($"Pago a recibir: {CalcularPago():C}");
        }
    }
}