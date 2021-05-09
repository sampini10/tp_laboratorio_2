using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        #region CONSTRUCTORES
        /// <summary>
        /// Constructor que recibe por parametros los valores y reutiliza el constructor de base.
        /// </summary>
        /// <param name="marca">Recibe la marca por parametro</param>
        /// <param name="chasis">Recibe el chasis por parametro</param>
        /// <param name="color">Recibe el color por parametro</param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color)
        {

        }
        #endregion
        #region METODOS
        /// <summary>
        /// Ciclomotor son 'Chico', retorna siempre el tamaña chico
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }
        /// <summary>
        /// Metodo mostrar de Sedan, reutiliza el metodo mostrar de la base. Mostrando tmb el tamaño del ciclomotor.
        /// </summary>
        /// <returns></returns>

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("---CICLOMOTOR---");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion 
    }
}
