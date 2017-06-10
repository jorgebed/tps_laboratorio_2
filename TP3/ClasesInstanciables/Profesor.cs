using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;
using System.Collections;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        private void _randomClases()
        {            
            int nro = Profesor._random.Next(1, 4);
            //System.Threading.Thread.Sleep(2000);

            switch (nro)
            {
                case 1:
                    this._clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                    break;
                case 2:
                    this._clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                    break;
                case 3:
                    this._clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Sobrescribir el método MostrarDatos con todos los datos del alumno.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("PROFESOR: ");
            sb.Append(base.ToString());
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());            

            return sb.ToString();
        }

        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases item in i._clasesDelDia)
            {
                if (item == clase)
                    return true;
            }

            return false;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// ParticiparEnClase retornará la cadena "CLASES DEL DÍA " junto al nombre de la clases que da.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            //return "CLASES DEL DIA: " + this._clasesDelDia;
            foreach (Universidad.EClases item in this._clasesDelDia)
            {
                sb.AppendLine("CLASES DEL DIA: " + item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// En el constructor de instancia se inicializará ClasesDelDia y se asignarán dos clases al azar al Profesor mediante el método randomClases. 
        /// Las dos clases pueden o no ser la misma.
        /// </summary>
        public Profesor()
        {
            
        }

        /// <summary>
        /// Se inicializará a Random sólo en un constructor.
        /// </summary>
        static Profesor()
	    {
            Profesor._random = new Random();
	    }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }

        /// <summary>
        /// ToString hará públicos los datos del Profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
