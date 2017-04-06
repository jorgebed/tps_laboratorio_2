using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_WF
{
    class Calculadora
    {
        /// <summary>
        /// Método de clase. Su valor de retorno será del tipo double. Si no puede operar (división por 0), retornará 0.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>double</returns>
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            double numero = 0;

            switch (operador)
            {
                case "+":
                    numero = numero1.getNumero() + numero2.getNumero();
                    break;
                case "-":
                    numero = numero1.getNumero() - numero2.getNumero();
                    break;
                case "*":
                    numero = numero1.getNumero() * numero2.getNumero();
                    break;
                case "/":
                    if (numero2.getNumero() == 0)
                        return 0;
                    else
                        numero = numero1.getNumero() / numero2.getNumero();
                    break;
            }
            return numero;
        }

        /// <summary>
        /// Método de clase. Validará que el operador sea un caracter válido, caso contrario retornará “+”.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        public string validarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
                return operador;
            else
                return "+";
        }
    }
}
