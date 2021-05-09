using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        #region ENUM
        /// <summary>
        /// Enumerado de las marcas de un vehiculo
        /// </summary>
        public enum EMarca
        {
            Chevrolet, 
            Ford, 
            Renault,
            Toyota,
            BMW, 
            Honda, 
            HarleyDavidson
        }
        /// <summary>
        /// Tamaño de un vehiculo
        /// </summary>
        public enum ETamanio
        {
            Chico, 
            Mediano, 
            Grande
        }
        #endregion
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;

        #region CONSTRUCTOR
        /// <summary>
        /// Constructor de vehiculo
        /// </summary>
        /// <param name="chasis"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }
        #endregion
        #region PROPIEDADES
        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio { get; }
        #endregion
        #region METODOS
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        /// <summary>
        /// Retorna los valores del vehiculos, previamente casteado para poder hacerlo.
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);
            sb.AppendFormat("MARCA : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR : {0}\r\n", p.color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /////// <summary>
        /////// Dos vehiculos son iguales si comparten el mismo chasis
        /////// </summary>
        /////// <param name="v1">Primer vehiculo para comparar</param>
        /////// <param name="v2">Segundo vehiculo para comparar</param>
        /////// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /////// <summary>
        /////// Dos vehiculos son distintos si su chasis es distinto
        /////// </summary>
        /////// <param name="v1">Primer vehiculo para comparar</param>
        /////// <param name="v2">Segundo vehiculo para comparar</param>
        /////// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis != v2.chasis);
        }
        #endregion
    }
}
