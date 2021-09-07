using System;
using System.Collections;



namespace Full_GRASP_And_SOLID.Library
{
    public class ProductionCost
    {
        //recibe como parametro los pasos de preparacion, que contienen productos, cantidades, equipo y tiempo
        public ProductionCost(Step preparacion)
        {
            this.Prep = preparacion;  
        }
        public Step Prep {get;set;}

        public double CostoInsumos()        // calcula el costo de los insumos para elaborar
        {
            double costoInsumos = 0;
            costoInsumos = this.Prep.Input.UnitCost;
            return costoInsumos;
        }
        public double CostoEquipo()   //calcula el costo de utilizar el equipo
        {
            double costoEquipo = 0;
            costoEquipo += this.Prep.Time * this.Prep.Equipment.HourlyCost / 60;
            return costoEquipo;
        }

       
        public string CalCost()     //Calcula el costo de realizar cada paso de la preparacion
        {
            double subTotalEquipo = CostoEquipo();
            double subTotalMateriales = CostoInsumos();
            double costoFinal = subTotalEquipo+subTotalMateriales;
            string costoFinalStr = $"Preparar {this.Prep.Input.Description}: Costo Equipo ${subTotalEquipo.ToString()} + Costo Materiales ${subTotalMateriales.ToString()} = Costo ${costoFinal.ToString()}\n";
            return costoFinalStr;
        }
    }
}