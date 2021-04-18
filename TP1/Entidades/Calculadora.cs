using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valido el operador que recibo del tipo char, si no es ninguno de los operadores, devuelvo un +
        /// </summary>
        /// <param name="operador">Recibo operador del tipo char</param>
        /// <returns>Retorno el operador que recibo en string</returns>
        private static string ValidarOperador(char operador)
        {
            if (operador == '-' || operador == '+' || operador == '/' || operador == '*')
            {
                return operador.ToString();
            }
            else
            {
                return "+";
            }
        }
        /// <summary>
        /// El metodo operar, recibe dos valores del tipo numero y un operador tipo string, el operador va a ser validado
        /// en el metodo validarOperador, previamente lo convierto a char y luego recibo el string que uso en el switch que 
        /// realiza la operacion seleccionada
        /// </summary>
        /// <param name="numero1">Valor del tipo numero</param>
        /// <param name="numero2">Valor del tipo numero </param>
        /// <param name="operador">Valor operador del tipo string</param>
        /// <returns>Retorno el resultado de la operacion en double</returns>
        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado = 0;
            char auxValidar;
            char.TryParse(operador, out auxValidar);

            switch (ValidarOperador(auxValidar))
            {
                case "-":
                    resultado = numero1 - numero2;
                    break;
                case "+":
                    resultado = numero1 + numero2;
                    break;
                case "*":
                    resultado = numero1 * numero2;
                    break;
                case "/":
                    resultado = numero1 / numero2;
                    break;
            }
            return resultado;
        }

    }
}
