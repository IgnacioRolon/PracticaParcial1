using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum Posicion
    {
        Arquero,
        Defensor,
        Central,
        Delantero
    }
    public class Jugador:Persona
    {
        private float altura;
        private float peso;
        private Posicion posicion;

        public float Altura
        {
            get
            {
                return this.altura;
            }
        }
        public float Peso
        {
            get
            {
                return this.peso;
            }
        }
        public Posicion Posicion
        {
            get
            {
                return this.posicion;
            }
        }

        public Jugador(string nombre, string apellido, int edad, int dni, float peso, float altura, Posicion posicion)
            :base(nombre, apellido, edad, dni)
        {
            this.altura = altura;
            this.peso = peso;
            this.posicion = posicion;
        }
        public override string Mostrar()
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("{0}, Peso: {1}, Altura: {2}, Posicion: {3}", base.Mostrar(), this.peso.ToString(), this.altura.ToString(), this.posicion.ToString());
            return str.ToString();
        }

        /// <summary>
        /// Valida el estado fisico de un jugador. Su IMC debe ser mayor a 18.5 y menor a 25.
        /// </summary>
        /// <returns>Devuelve si está en estado fisico.</returns>
        public bool ValidarEstadoFisico()
        {
            float IMC = 0;
            IMC = this.peso / float.Parse(Math.Pow(altura, 2).ToString()); 
            if(IMC >= 18.5 && IMC <= 25)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Valida si el jugador es apto. Debe estar en estado fisico y tener menos de 40 años.
        /// </summary>
        /// <returns>Devuelve si el jugador es apto.</returns>
        public override bool ValidarAptitud()
        {
            if(this.Edad <= 40 && ValidarEstadoFisico() == true)
            {
                return true;
            }
            return false;
        }
    }
}
