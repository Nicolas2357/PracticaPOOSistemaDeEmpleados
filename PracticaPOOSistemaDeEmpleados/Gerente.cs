using PracticaPOOSistemaDeEmpleados.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaPOOSistemaDeEmpleados
{
    public class Gerente : Empleado, IEvaluable
    {
        public decimal BonoPorDesempeno { get; set; }
        public int CantidadEmpleadosACargo { get; set; }

        public Gerente(int id, string nombre, DateTime fechaContratacion, decimal salarioBase,
            decimal bonoPorDesempeno, int cantidadEmpleadosACargo)
            : base(id, nombre, fechaContratacion, salarioBase)
        {
            BonoPorDesempeno = bonoPorDesempeno;
            CantidadEmpleadosACargo = cantidadEmpleadosACargo;
        }

        public override decimal CalcularPago()
        {
            return SalarioBase + BonoPorDesempeno + (CantidadEmpleadosACargo * 50m);
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Tipo: Gerente");
            Console.WriteLine($"Bono por desempeño: {BonoPorDesempeno:C}");
            Console.WriteLine($"Empleados a cargo: {CantidadEmpleadosACargo}");
        }
        public string GenerarReporteDesempeño()
        {
            return $"{Nombre} supervisa a {CantidadEmpleadosACargo} empleados y mantiene un bono por desempeño de {BonoPorDesempeno:C}.";
        }
    }
}
