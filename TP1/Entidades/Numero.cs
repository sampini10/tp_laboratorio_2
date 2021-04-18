using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {

        private double numero;
        #region CONSTRUCTORES
        /// <summary>
        /// Creamos los constructores, primero constructor por defecto que inicializa al numero en 0
        /// El segundo recibe el numero, reutilizamos codigo para que use el tercer constructor
        /// y convierta string, validando y seteandolo.
        /// </summary>
        public Numero():this(0)
        {
            
        }
        public Numero(double numero) : this(numero.ToString())
        {

        }
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion
        #region SETTER
        /// <summary>
        /// Con el set, valido que el valor recibido sea numerico y de ser asi, lo seteo en numero
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }

        }
        /// <summary>
        /// Propiedad que valida un string, verificando que sea un numero. En caso de retornar 0, no es un numero.
        /// </summary>
        /// <param name="strNumero">Recibe solamente de SetNumero, un string a validar como numero.</param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            double auxNumero;
            if (double.TryParse(strNumero, out auxNumero))
            {
                return auxNumero;
            }
            return auxNumero = 0;
        }
        #endregion

        #region METODOS BINARIOS/DECIMAL
        /// <summary>
        /// Metodo que recibe un valor por string, que debe validar que sea un numero binario, de no ser asi retorna false.
        /// Verifica que solo sean 0 y 1, los valores.
        /// </summary>
        /// <param name="binario">Recibe un binario en string</param>
        /// <returns></returns>
        private static bool EsBinario(string binario)
        {
            bool retorno = true;
            char[] arrayAux = binario.ToCharArray();
            for (int i = 0; i < arrayAux.Length; i++)
            {
                if (arrayAux[i] != '0' && arrayAux[i] != '1')
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Recibe un binario, que debe validar que sea un numero binario, de ser asi generamos un array de char, que recorre buscando 
        /// los 1 que contiene el binario. El reverse permite que el array se recorra de atras para adelante.
        /// El metodo pow, lo que hace es que 2 se eleve al numero de i, cada vez que encuentre un 1
        /// </summary>
        /// <param name="binario">Binario que recibe.</param>
        /// <returns>Retornara el numero decimal en string </returns>
        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor invalido";
            double suma = 0;
            char[] arrayAux = binario.ToCharArray();
            Array.Reverse(arrayAux);

            if (EsBinario(binario))
            {
                for (int i = 0; i < arrayAux.Length; i++)
                {
                    if (arrayAux[i] == '1')
                    {
                        suma = suma + Math.Pow(2, i);
                    }
                }
                retorno = suma.ToString();
            }
            return retorno;
        }
        /// <summary>
        /// Recibe un numero decimal, el cual verifica que sea mayor que 0, cuando el resto sea 0 agrega el 0 y sino agrega el 1.
        /// Auxnumero, guarda el resultado para poder devidirlo nuevamente por 2 y sacar nuevamente el resto.
        /// Hasta que auxNumero sea 0, de recibir un 0, retornara un 0 sino un Valor invalido.
        /// </summary>
        /// <param name="numero">Recibe el numero a convertir en binario</param>
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {
            string retorno = "";
            int auxNumero = (int)numero;

            if (auxNumero > 0)
            {
                do
                {
                    if (auxNumero % 2 == 0)
                    {
                        retorno = "0" + retorno;
                    }
                    else
                    {
                        retorno = "1" + retorno;
                    }

                    auxNumero = auxNumero / 2;

                } while (auxNumero > 0);

            }
            else
            {
                if (auxNumero == 0)
                {
                    retorno = "0";
                }
                else
                {
                    retorno = "Valor Invalido";
                }
            }

            return retorno;
        }
        /// <summary>
        /// Recibe un string que se parsea a double, que se va utilizar en el metodo decimalbinario que recibe un double, el cual 
        /// retorna el binario.
        /// </summary>
        /// <param name="numero">Es recibido en string para luego parsearlo</param>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            string retorno = "Valor invalido";
            double numAux;
            if (double.TryParse(numero, out numAux))
            {
                retorno = DecimalBinario(numAux);
            }
            return retorno;
        }
        #endregion
        #region SOBRECARGA DE OPERADORES
        /// <summary>
        /// Resta dos valores de tipo numero
        /// </summary>
        /// <param name="n1">Valor de tipo numero</param>
        /// <param name="n2">Valor de tipo numero</param>
        /// <returns>Retorna el resultado de la resta</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero; 
        }
        /// <summary>
        /// Hace la suma de dos valores de tipo numero
        /// </summary>
        /// <param name="n1">Valor de tipo numero</param>
        /// <param name="n2">Valor de tipo numero</param>
        /// <returns>Retorna el resultado de la suma</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Multiplica dos valores de tipo numero
        /// </summary>
        /// <param name="n1">Valor del tipo numero </param>
        /// <param name="n2">Valor del tipo numero</param>
        /// <returns>Retorna el resultado de la multiplicacion</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Divide dos valores del tipo numero, que verifica que el valor de n2, no sea 0, caso que lo sea, devuelve double.minvalue
        /// </summary>
        /// <param name="n1">Valor del tipo numero</param>
        /// <param name="n2">Valor del tipo numero</param>
        /// <returns>Va a retornar el resultado de la division, siempre y cuando, n2 no sea 0. Caso de ser 0, retorna double.minValue</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = double.MinValue;
            if(n2.numero != 0)
            {
                retorno = n1.numero / n2.numero;
            }

            return retorno;
        }
        #endregion
    }
}
