﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QEQ2.Models
{
    public class Personajes
    {
        private string _Nombre;
        private int _Categoria;

        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public int Categoria { get => _Categoria; set => _Categoria = value; }

        public Personajes()
        {

        }

        public Personajes(string NOMING, int CATING)
        {
          _Nombre=NOMING;
          _Categoria= CATING;
        }
    }
}