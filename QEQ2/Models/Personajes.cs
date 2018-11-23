   using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QEQ2.Models
{
    public class Personajes
    {
        private string _Nombre;
        private int _Categorias;
        private int _idPersonaje;
        private string _Imagen;
       
        public Personajes()
        {

        }
        public Personajes(string Nombre, int Categorias, int idPersonajes, string Imagen)
        {
         _Nombre= Nombre;
         _Categorias= Categorias;
         _idPersonaje = idPersonajes;
         _Imagen = Imagen;
        }

        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public int Categoria { get => _Categorias; set => _Categorias = value; }
        public int IdPersonaje { get => _idPersonaje; set => _idPersonaje = value; }
        public string Imagen { get => _Imagen; set => _Imagen = value; }
    }
}