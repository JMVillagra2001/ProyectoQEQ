using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QEQ2.Models
{
    public class Categoria
    {
        private int _idCategoria;
        private string _Nombre;

        public Categoria()
        {
            _idCategoria = IdCategoria;
            _Nombre = Nombre;
        }
        public Categoria(int idCategoria, string Nombre)
        {
            _idCategoria = idCategoria;
            _Nombre = Nombre;
        }

        public int IdCategoria { get => _idCategoria; set => _idCategoria = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
    }
}