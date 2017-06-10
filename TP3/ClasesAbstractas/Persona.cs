using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace ClasesAbstractas
{
    public abstract class Persona
    {
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #region Propiedades

        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = ValidarNombreApellido(value); }
        }

        public int DNI
        {
            get { return this._dni; }

            set
            {
                this._dni = ValidarDni(this.Nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }

        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = ValidarNombreApellido(value); }
        }

        public string StringToDNI
        {
            set
            {
                this._dni = ValidarDni(this.Nacionalidad, value);
            }
        }

        #endregion

        public Persona()
        {
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad):this()//llamo al constructor por default por si en algún momento se quiere agregar valores por defecto
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// ToString retornará los datos de la Persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            sb.AppendLine("DNI: " + this.DNI);
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad);
            return sb.ToString();
        }

        /// <summary>
        /// Se deberá validar que el DNI sea correcto, teniendo en cuenta su nacionalidad. Argentino entre 1 y 89999999. 
        /// Caso contrario, se lanzará la excepción DniInvalidoException.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int dniValidado = 0;            
            
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato > 0 && dato <= 89999999)                    
                        dniValidado = dato;                    
                    else
                        throw new DniInvalidoException("La nacionalidad no se condice con el número de DNI");
                    break;

                case ENacionalidad.Extranjero:                    
                    if (dato > 89999999 && dato <= 99999999)                    
                        dniValidado = dato;                    
                    else
                        throw new DniInvalidoException("La nacionalidad no se condice con el número de DNI");
                    break;

                default:
                    throw new Exception("La nacionalidad no existe");
            }
           
            return dniValidado;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            bool isOk = false;
            int dni = 0;

            isOk = int.TryParse(dato, out dni);

            if (isOk)
                return ValidarDni(nacionalidad, dni);
            else
                throw new DniInvalidoException("DNI inválido");
        }

        /// <summary>
        /// Validará que los nombres sean cadenas con caracteres válidos para nombres. Caso contrario, no se cargará.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            bool isOk = false;

            for (int i = 0; i < dato.Length; i++)
            {
                isOk = char.IsLetter(dato, i);
                if (isOk == false)
                {
                    dato = null;
                    break;
                }
            }
            return dato;
        }
    }
}
