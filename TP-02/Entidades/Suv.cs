using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Constructor que recibe por parametros los valores y luego reutiliza el constructor base.
        /// </summary>
        /// <param name="marca">Recibe la marca por parametro</param>
        /// <param name="chasis">Recibe el chasis por parametro</param>
        /// <param name="color">Recibe el color por parametro</param>
        public Suv(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color)
        {
            
        }
        #endregion
        #region METODOS
        /// <summary>
        /// SUV son 'Grande', retorna siempre el tamaño grande.
        /// </summary>
        protected override ETamanio Tamanio 
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        /// <summary>
        /// Metodo mostrar de Suv, reutiliza el metodo mostrar de la base. Mostrando tmb el tamaño se Suv.
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("---SUV---");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
