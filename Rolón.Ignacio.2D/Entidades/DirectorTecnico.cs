using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DirectorTecnico:Persona
    {
        private int añosExperiencia;
        public int AñosExperiencia
        {
            get
            {
                return this.añosExperiencia;
            }
            set
            {
                this.añosExperiencia = value;
            }
        }
        public DirectorTecnico(string nombre, string apellido, int edad, int dni, int añosExperiencia)
            :base(nombre, apellido, edad, dni)
        {
            this.añosExperiencia = añosExperiencia;
        }
        public override string Mostrar()
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("{0}, Años de Experiencia: {1}", base.Mostrar(), this.añosExperiencia);
            return str.ToString();
        }

        /// <summary>
        /// Un director tecnico es apto si tiene menos de 65 años y 2 o mas años de experiencia
        /// </summary>
        /// <returns>Devuelve si es apto.</returns>
        public override bool ValidarAptitud()
        {
            if(this.Edad < 65 && this.añosExperiencia >= 2)
            {
                return true;
            }
            return false;
        }
    }
}
