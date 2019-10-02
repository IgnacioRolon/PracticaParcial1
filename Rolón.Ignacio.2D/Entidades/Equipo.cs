using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Equipo
    {
        private const int cantidadMaximaJugadores = 6;
        private DirectorTecnico directorTecnico;
        private List<Jugador> jugadores;
        private string nombre;

        /// <summary>
        /// El director tecnico se define solo si es apto.
        /// </summary>
        public DirectorTecnico DirectorTecnico
        {
            set
            {
                if (value.ValidarAptitud() == true)
                {
                    this.directorTecnico = value;
                }
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }
        private Equipo()
        {
            this.jugadores = new List<Jugador>();
        }
        public Equipo(string nombre)
            : this()
        {
            this.nombre = nombre;
        }

        /// <summary>
        /// Devuelve el DT del equipo y sus jugadores.
        /// </summary>
        /// <param name="e">Equipo a castear.</param>
        public static explicit operator string(Equipo e)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(e.nombre);
            if (e.directorTecnico == null)
            {
                str.AppendLine("Sin DT asignado");
            }
            else
            {
                str.AppendLine(e.directorTecnico.Mostrar());
            }
            foreach (Jugador jugador in e.jugadores)
            {
                str.AppendLine(jugador.Mostrar());
            }
            return str.ToString();
        }
        public static bool operator ==(Equipo e, Jugador j)
        {
            foreach(Jugador jugador in e.jugadores)
            {
                if(jugador == j)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Equipo e, Jugador j)
        {
            return !(e == j);
        }

        /// <summary>
        /// Se agrega un jugador al equipo solo si hay espacio en el equipo, no existe en el mismo y el jugador es apto.
        /// </summary>
        /// <param name="e">Equipo a agregar el jugador</param>
        /// <param name="j">Jugador a agregar</param>
        /// <returns>Equipo modificado.</returns>
        public static Equipo operator +(Equipo e, Jugador j)
        {
            if(e.jugadores.Count < cantidadMaximaJugadores && j.ValidarAptitud() == true)
            {
                foreach(Jugador jugador in e.jugadores)
                {
                    if(jugador == j)
                    {
                        return e;
                    }
                }
                e.jugadores.Add(j);
            }
            return e;
        }

        /// <summary>
        /// Valida el equipo. Es valido si tiene 1 arquero, si tiene director tecnico, 
        /// si tiene la cantidad maxima de jugadores y si tiene 1 de cada posicion.
        /// </summary>
        /// <param name="e">Equipo a validar</param>
        /// <returns>Devuelve si el equipo es valido.</returns>
        public static bool ValidarEquipo(Equipo e)
        {
            int cantidadArqueros = 0;
            int cantidadDefensores = 0;
            int cantidadCentrales = 0;
            int cantidadDelanteros = 0;
            if(e.directorTecnico != null)
            {
                foreach(Jugador jugador in e.jugadores)
                {
                    switch(jugador.Posicion)
                    {
                        case Posicion.Arquero:
                            cantidadArqueros++;                            
                            break;
                        case Posicion.Defensor:
                            cantidadDefensores++;
                            break;
                        case Posicion.Central:
                            cantidadCentrales++;
                            break;
                        case Posicion.Delantero:
                            cantidadDelanteros++;
                            break;
                    }                    
                }
                if(e.jugadores.Count == cantidadMaximaJugadores)
                {
                    if(cantidadArqueros == 1 && cantidadCentrales > 0 && cantidadDefensores > 0 && cantidadDelanteros > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
