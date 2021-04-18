using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {

        }
        
        /// <summary>
        /// Boton que llama al metodo limpiar, que limpia numeros, operadores y resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// Metodo que limpia los numeros, operador y resultado.
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "Resultado";
            this.cmbOperador.SelectedIndex = -1;
            this.btnConvertBinario.Enabled = true;
            this.btnConvertDecimal.Enabled = true;
        }
        /// <summary>
        /// Boton que cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Boton que realiza la operacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            resultado = FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            this.lblResultado.Text = resultado.ToString();
        }
        /// <summary>
        /// Metodo Operar que recibe los numeros y el operador, retornando el resultado
        /// </summary>
        /// <param name="numero1">recibe el numero de txt.numero1</param>
        /// <param name="numero2">recibe el numero de txt.numero2</param>
        /// <param name="operador">recibe el operador de cmbOperador</param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero primerNumero = new Numero(numero1);
            Numero segundoNumero = new Numero(numero2);
            double resultado;

            resultado = Calculadora.Operar(primerNumero, segundoNumero, operador);

            return resultado;      
        }
        /// <summary>
        /// Boton que convierte a binario el resultado obtenido en entero.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnConvertBinario_Click(object sender, EventArgs e)
        {
            Numero numAuxiliar = new Numero();
            this.lblResultado.Text = numAuxiliar.DecimalBinario(lblResultado.Text);
            this.btnConvertDecimal.Enabled = true;
            this.btnConvertBinario.Enabled = false;
        }
        /// <summary>
        /// Boton que convierte a decimal, el numero binario ingresado o obtenido.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertDecimal_Click(object sender, EventArgs e)
        {
            Numero numAuxiliar = new Numero();
            this.lblResultado.Text = numAuxiliar.BinarioDecimal(lblResultado.Text);
            this.btnConvertDecimal.Enabled = false;
            this.btnConvertBinario.Enabled = true;
        }

    }
}
