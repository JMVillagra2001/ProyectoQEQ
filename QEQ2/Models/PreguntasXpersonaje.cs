using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QEQ2.Models
{
    public class PreguntasXpersonaje
    {
        private int _IdPersonaje;
        private int _IdPreguntas;

        public int IdPersonaje { get => _IdPersonaje; set => _IdPersonaje = value; }
        public int IdPreguntas { get => _IdPreguntas; set => _IdPreguntas = value; }

        public PreguntasXpersonaje(int IdPersonajes, int IdPreguntas)
        {
            _IdPersonaje = IdPersonajes;
            _IdPreguntas = IdPreguntas;
        }
        
        public PreguntasXpersonaje()
        {

        }
    }
    
}