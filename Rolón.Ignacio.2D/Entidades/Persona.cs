using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private int edad;
        private string nombre;
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
        }
        public int Dni
        {
            get
            {
                return this.dni;
            }
        }
        public int Edad
        {
            get
            {
                return this.edad;
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }
        public Persona(string nombre, string apellido, int edad, int dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.dni = dni;
        }
        /// <summary>
        /// Muestra toda la información de la persona. Puede ser sobrescrita. 
        /// </summary>
        /// <returns>Devuelve un string con la informacion de la persona.</returns>
        public virtual string Mostrar()
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("Nombre: {0}, Apellido: {1}, Edad: {2}, DNI: {3}", this.nombre, this.apellido, this.edad.ToString(), this.dni.ToString());
            return str.ToString();        
        }
        public abstract bool ValidarAptitud();
    }
}
