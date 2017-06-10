using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            //set { this.alumnos (this, value); }
        }

        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            //set { myVar = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornadas; }
            //set { myVar = value; }
        }

        public Jornada this[int i]
        {
            get
            {
                if (i < 0)
                    return null;
                else
                    return this.jornadas[i];
            }
            set
            {
                if (i >= 0)
                {
                    this.jornadas[i] = value;
                }
                else                
                    Console.WriteLine("No se puede asignar a este elemento");                
            }
        }

        /// <summary>
        /// Guardar de clase serializará los datos del Universidad en un XML, incluyendo todos los datos de sus Profesores, Alumnos y Jornadas.
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad gim)
        {
            XmlTextWriter XmlTw = new XmlTextWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Universidad.xml", Encoding.UTF8);
            XmlSerializer XmlSer = new XmlSerializer(typeof(Universidad));

            XmlSer.Serialize(XmlTw, gim);
            XmlTw.Close();
            return true;
        }

        /// <summary>
        /// MostrarDatos será privado y de clase.
        /// </summary>
        /// <returns></returns>
        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in gim.Alumnos)
            {
                sb.Append(item.ToString());
            }

            sb.AppendLine("JORNADAS: ");
            foreach (Jornada item in gim.Jornadas)
            {
                sb.Append(item.ToString());
            }

            sb.AppendLine("PROFESORES: ");
            foreach (Profesor item in gim.Instructores)
            {
                sb.Append(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Una Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno item in g.Alumnos)
            {
                if (item == a)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase. 
        /// Sino, lanzará la Excepción SinProfesorException.        
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor item in g.profesores)
            {
                if (item == clase)
                    return item;
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// /// El distinto retornará el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor item in g.profesores)
            {
                if (item != clase)
                    return item;
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Una Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor item in g.profesores)
            {
                if (item == i)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if(g == a)
                throw new AlumnoRepetidoException();
            else
                g.alumnos.Add(a);
            return g;            
        }

        /// <summary>
        /// Al agregar una clase a una Universidad se deberá generar y agregar una nueva Jornada indicando la clase, 
        /// un Profesor que pueda darla (según su atributo ClasesDelDia) 
        /// y la lista de alumnos que la toman (todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada nuevaJornada = new Jornada(clase, (g == clase));

            g.jornadas.Add(nuevaJornada);

            foreach (Alumno item in g.Alumnos)
            {
                if (item == clase)
                    nuevaJornada.Alumnos.Add(item);
            }
            
            return g;            
        }

        /// <summary>
        /// Se agregarán Alumnos y Profesores mediante el operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
                g.profesores.Add(i);
            
            return g;
        }

        /// <summary>
        /// Los datos de la Universidad se harán públicos mediante ToString.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornadas = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
    }
}
