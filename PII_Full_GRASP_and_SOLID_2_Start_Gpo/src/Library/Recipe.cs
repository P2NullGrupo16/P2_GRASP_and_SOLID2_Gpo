//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;
using System.Text;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }
        

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }


        /* Basicamente lo que se hizo fue cambiar el formato de como estaba pensado inicialmente el metodo PrintRecipe, y se le agrego Text al final del nombre del metodo
        para indicar que ahra lo que va a devolver va a ser un String.
        Se ajustaron algunos detalles que permitiera realizar esto y se creo una nueva clase ConsolePrinter como se pedia en la letra que recibe como parametro el string que devuelve el
        metodo PrintRecipeText.
        Como la clase ConsolePrinter es la encargada de imprimir en Consola, se le derivaron todas las responsabilidades a tal tarea, para esto se utiliza el patron EXPERT.
        y a su vez tambien se aplica el principio SRP ya que ahora la clase Recipe ya no tiene la responsabilidad de imprimir la receta.    */
        public string PrintRecipeText()
        {
            int count = 1;
            StringBuilder textoReceta = new StringBuilder($"\nReceta de {this.FinalProduct.Description}:\n");
            foreach (Step step in this.steps)
            {
                textoReceta.Append($"{count}- Colocar {step.Quantity} de '{step.Input.Description}' usando '{step.Equipment.Description}' durante {step.Time}.\n");
                count++;
            }
            textoReceta.Append(GetProductionCost());
            return textoReceta.ToString();

        }
        public string GetProductionCost()   // este metodo funciona para devolver el costo total de la preparacion
        {
            double Total = 0;
            StringBuilder textCosto = new StringBuilder("\nCostos de producción:\n");
            foreach (Step item in steps)
            {
                ProductionCost a =new ProductionCost(item);
                textCosto.Append(a.CalCost());
                Total += a.CostoInsumos() + a.CostoEquipo();
            }
            textCosto.Append($"Costo Total de la prepararación es de ${Total}.\n");
            return textCosto.ToString();
             
        }
    }
}