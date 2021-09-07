using System;
using System.Collections;
using System.Text;
using Full_GRASP_And_SOLID.Library;

namespace Full_GRASP_And_SOLID
{
    public class ConsolePrinter
    {
        public static void ImprimirReceta(Recipe receta)
        {
            Console.WriteLine(receta.PrintRecipeText());
        }
    }

}