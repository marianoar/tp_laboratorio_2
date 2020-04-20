using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Realiza la operacion solicitada entre dos numeros
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <param name="operador">string con la operacion a realizar</param>
        /// <returns>doube con el resultado de la operacion</returns>
        public static double Operar(Numero number1, Numero number2, string operador)
        {
            double result=0;
            switch (operador)
            {
                case "+":
                    result = number1 + number2;
                    break;
                case "-":
                    result = number1 - number2;
                    break;
                case "*":
                    result = number1 * number2;
                    break;
                case "/":
                    result = number1 / number2;
                    break;
            }
            return result;

        }
        /// <summary>
        /// Valida q el strign operador contenga una operacion matematica correcta
        /// </summary>
        /// <param name="operador">contiene signo de la operacion</param>
        /// <returns>retorna el operador valido o en su defecto +</returns>
        private static string ValidarOperador(string operador)
        {
            string retorno = "+";
            switch (operador)
            {
                case "-":
                    retorno = operador;
                    break;
                case "*":
                    retorno = operador;
                    break;
                case "/":
                    retorno = operador;
                    break;
            }
            return retorno;
        }
    }
}
