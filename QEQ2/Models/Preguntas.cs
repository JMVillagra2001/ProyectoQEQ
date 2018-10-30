using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QEQ2.Models
{
    public class Preguntas
    {
        private int _idPregunta;
        private string _texto;
        private int _idCategoria;

        public Preguntas()
        {
            _idPregunta = IdPregunta;
            _texto = Texto;
            _idCategoria = IdCategoria;
        }
        public Preguntas(int idPregunta, string texto, int idCategoria)
        {
            _idPregunta = idPregunta;
            _texto = texto;
            _idCategoria = idCategoria;
        }

        public int IdPregunta { get => _idPregunta; set => _idPregunta = value; }
        public string Texto { get => _texto; set => _texto = value; }
        public int IdCategoria { get => _idCategoria; set => _idCategoria = value; }
    }
}