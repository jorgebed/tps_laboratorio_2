using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_WF
{
    public partial class Form1 : Form
    {       
        public Form1()
        {
            InitializeComponent();
            this.Text = "Calculadora";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {            
        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {           
        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {            
        }

        /// <summary>
        /// Realiza la operación matemática correspondiente y se muestra el resultado por pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            Calculadora c = new Calculadora();                        
            Numero numero1 = new Numero(this.txtNumero1.Text);
            Numero numero2 = new Numero(this.txtNumero2.Text);
            string operador = c.validarOperador(this.cmbOperacion.Text);
            
            //Se setean valores válidos por defecto en la calculadora en caso que el usuario ingrese valores no numerales
            this.cmbOperacion.Text = operador;
            this.txtNumero1.Text = numero1.getNumero().ToString();
            this.txtNumero2.Text = numero2.getNumero().ToString();
            
            double resultado = Calculadora.operar(numero1, numero2, operador);
            this.lblResultado.Text = resultado.ToString();
        }

        /// <summary>
        /// Borra todos los campos de la calculadora.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperacion.Text = "";
            this.lblResultado.Text = "";
        }
    }
}
