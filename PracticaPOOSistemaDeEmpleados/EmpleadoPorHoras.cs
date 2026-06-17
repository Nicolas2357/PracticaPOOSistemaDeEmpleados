using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaPOOSistemaDeEmpleados
{
    public class EmpleadoPorHoras : Empleado
    {
        public int HorasTrabajadas { get; set; }
        public decimal TarifaPorHora { get; set; }

        public EmpleadoPorHoras(int id, string nombre, DateTime fechaContratacion,
            decimal salarioBase, int horasTrabajadas, decimal tarifaPorHora)
            : base(id, nombre, fechaContratacion, salarioBase)
        {
            HorasTrabajadas = horasTrabajadas;
            TarifaPorHora = tarifaPorHora;
        }

        public override decimal CalcularPago()
        {
            return SalarioBase + (HorasTrabajadas * TarifaPorHora);
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Tipo: Por horas");
            Console.WriteLine($"Horas trabajadas: {HorasTrabajadas}");
            Console.WriteLine($"Tarifa por hora: {TarifaPorHora:C}");
        }
    }
}
