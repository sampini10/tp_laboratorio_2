using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        /// <summary>
        /// Enumerado de Sedan que puede ser Cuatro puertas o cincon puertas.
        /// </summary>
        public enum ETipo
        {
            CuatroPuertas,
            CincoPuertas
        }
        private ETipo tipo;

        /// <summary>
        /// Constructor que recibe por parametros los valores y reutiliza el constructor de base, asignando por defecto que tipo sera de Cuatro puertas
        /// </summary>
        /// <param name="marca">Recibe la marca por parametro</param>
        /// <param name="chasis">Recibe el chasis por parametro</param>
        /// <param name="color">Recibe el color por parametro</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            this.tipo = ETipo.CuatroPuertas;
        }
        /// <summary>
        /// Constructore que recibe por parametros los valores y reutiliza el constructor de base.
        /// </summary>
        /// <param name="marca">Recibe la marca por parametro</param>
        /// <param name="chasis">Recibe el chasis por parametro</param>
        /// <param name="color">Recibe el color por parametro</param>
        /// <param name="tipo">Recibe el tipo por parametro</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo) : this(marca,chasis,color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Sedan son 'Mediano', retorna siempre el tamaño mediano.
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        /// <summary>
        /// Metodo mostrar de Sedan, reutiliza el metodo mostrar de la base. Mostrando tmb el tamaño y tipo de Sedan.
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("---SEDAN---");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}\r\n", this.Tamanio);
            sb.AppendFormat("TIPO : {0}\r\n",  this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
