using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Taller
    {
        /// <summary>
        /// Enumerado del taller que tendra Ciclomotor, sedan, suv o otros.
        /// </summary>
        public enum ETipo
        {
            Ciclomotor,
            Sedan,
            SUV,
            Todos
        }

        private List<Vehiculo> vehiculos;
        private int espacioDisponible;

        #region "Constructores"
        /// <summary>
        /// Inicializa la lista de los vehiculos
        /// </summary>
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        /// <summary>
        /// Parametro del espacio disponible de taller, que utiliza el constructor que inicializa la lista de vehiculos
        /// </summary>
        /// <param name="espacioDisponible">Recibe los espacios por parametros</param>
        public Taller(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns>Retorna la lista de los vehiculos del taller.</returns>
        public override string ToString()
        {
            return Taller.Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>Retorna los vehiculos del taller</returns>
        public static string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", taller.vehiculos.Count, taller.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in taller.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.SUV:
                        if(v is Suv)
                        sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Ciclomotor:
                        if(v is Ciclomotor)
                        sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Sedan:
                        if(v is Sedan)
                        sb.AppendLine(v.Mostrar());
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns></returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            bool yaEstaEnTaller = false;
            int contadorLugares = 0;

            foreach (Vehiculo auxiliar in taller.vehiculos)
            {
                if (auxiliar == vehiculo)
                {
                    yaEstaEnTaller = true;
                    break;
                }
                contadorLugares++;
            }

            if (!yaEstaEnTaller && contadorLugares < taller.espacioDisponible)
            {
                taller.vehiculos.Add(vehiculo);
            }

            return taller;
        }
        ///// <summary>
        ///// Quitará un elemento de la lista
        ///// </summary>
        ///// <param name="taller">Objeto donde se quitará el elemento</param>
        ///// <param name="vehiculo">Objeto a quitar</param>
        ///// <returns></returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            foreach (Vehiculo item in taller.vehiculos)
            {
                if (item == vehiculo)
                {
                    taller.vehiculos.Remove(vehiculo);
                    break;

                }

            }

            return taller;
        }
        #endregion
    }
}
