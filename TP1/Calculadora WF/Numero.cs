using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_WF
{
    class Numero
    {
        #region ATRIBUTOS

        private double numero;

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// inicializará el atributo numero en cero en 0.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        
        /// <summary>
        /// Recibirá un double y cargará en número.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// recibirá un String que validará y cargará en número.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string numero)
        {
            setNumero(numero);
        }

        #endregion

        #region METODOS

        public double getNumero()
        {
            return this.numero;
        }

        /// <summary>
        /// Este será el único lugar donde se podrá utilizar el método validarNumero.
        /// </summary>
        /// <param name="numero"></param>
        private void setNumero(string numero)
        {
            this.numero = ValidarNumero(numero);
        }

        /// <summary>
        /// Metodo privado y de clase. Validará que se trate de un double válido. caso contrario retornará 0.
        /// </summary>
        /// <param name="NumeroString"></param>
        /// <returns>double</returns>
        private static double ValidarNumero(string NumeroString)
        {
            double numero = 0;

            if (double.TryParse(NumeroString, out numero) == false)
                return 0;
            else
                return numero;
        }

        #endregion
    }
}
