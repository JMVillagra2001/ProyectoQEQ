using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QEQ2.Models
{
    public class Personajes
    {
        private string _Nombre;
        private int _Categoria;

        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }

        public int Categoria
        {
            get
            {
                return _Categoria;
            }

            set
            {
                _Categoria = value;
            }
        }

        public Personajes()
        {

        }

        public Personajes(string Nombre, int Categoria)
        {
          _Nombre= Nombre;
          _Categoria= Categoria;
        }
    }
}