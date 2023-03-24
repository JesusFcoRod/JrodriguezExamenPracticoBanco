using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SuperDigito
    {
        public static int CalcularSuperDigito(string Numero)
        {
            int Resultado = 0;
            try
            {
                //AGREGAR LOS DIGITOS DEL NUMERO A UN ARREGLO
                String[] ArregloChar = NumeroToArrayString(Numero);

                //CASTEAR DE STRING A INT ARRAY
                int[] NumerosConvertInt = ArregloStringToInt(ArregloChar);
                int Suma = NumerosConvertInt.Sum();

                while (Suma > 9)
                {
                    String ConvertirSuma = Suma.ToString();
                    String[] NewArregloChar = NumeroToArrayString(ConvertirSuma);
                    int[] NewNumerosConvertInt = ArregloStringToInt(NewArregloChar);
                    Suma = NewNumerosConvertInt.Sum();

                }
                Resultado = Suma;
                Console.WriteLine("El super digito del numero " + Numero +" Es: "+ Resultado);

            }
            catch (Exception)
            {

            }
            return Resultado;

        }
        public static string[] NumeroToArrayString(string Numero)
        {
            int TamCadena = Numero.Length;
            string[] ArregloChar = new string[TamCadena];

            for (int i = 0; i <= TamCadena - 1; i++)
            {
                string Num = Numero.Substring(i, 1);
                ArregloChar[i] = Num;

            }
            return ArregloChar;
        }

        public static int[] ArregloStringToInt(string[] NumerosString)
        {
            int[] numeros = new int[NumerosString.Length];
            numeros = NumerosString.Select(x => Convert.ToInt32(x)).ToArray();
            return numeros;
        }


    }
}
