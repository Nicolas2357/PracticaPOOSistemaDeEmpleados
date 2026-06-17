using PracticaPOOSistemaDeEmpleados.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaPOOSistemaDeEmpleados
{
    public class EmpleadoTiempoCompleto : Empleado, IEvaluable
    {
        public decimal BonoMensual { get; set; }

        public EmpleadoTiempoCompleto(int id, string nombre, DateTime fechaContratacion,
            decimal salarioBase, decimal bonoMensual)
            : base(id, nombre, fechaContratacion, salarioBase)
        {
            BonoMensual = bonoMensual;
        }

        public override decimal CalcularPago()
        {
            return SalarioBase + BonoMensual;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Tipo: Tiempo completo");
            Console.WriteLine($"Bono mensual: {BonoMensual:C}");
        }
        public string GenerarReporteDesempeño()
        {
            return $"{Nombre} es empleado de tiempo completo. Recibe un bono fijo mensual de {BonoMensual:C}, lo cual indica estabilidad salarial.";
        }
    }
    
}
