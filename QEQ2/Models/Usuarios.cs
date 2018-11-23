using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace QEQ2.Models
{
    public class Usuarios
    {
        private int _idUsuario;
        private string _nombre;
        private string _contraseña;
        private int _bitcoins;
        private string _imgPerfil;
        private bool _admin;

        public Usuarios(int idUsuario, string nombre, string contraseña, int bitcoins, string imgPerfil, bool admin)
        {
            this._idUsuario = idUsuario;
            this._nombre = nombre;
            this._contraseña = contraseña;
            this._bitcoins = bitcoins;
            this._imgPerfil = imgPerfil;
            this._admin = admin;
            
        }
        public Usuarios()
        {

        }

        public int IdUsuario
        {
            get
            {
                return _idUsuario;
            }

            set
            {
                _idUsuario = value;
            }
        }
        [Required(ErrorMessage = "Ingresá un nombre válido!!!")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Más de 4 letras y menos de 20 ")]
        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }
        [Required(ErrorMessage = "Ingresa una contraseña!!!")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Más de 8 letras y menos de 20 ")]
        public string Contraseña
        {
            get
            {
                return _contraseña;
            }

            set
            {
                _contraseña = value;
            }
        }

        public int Bitcoins
        {
            get
            {
                return _bitcoins;
            }

            set
            {
                _bitcoins = value;
            }
        }
        [Required(ErrorMessage = "Ingresa una imagen valido!!!")]
        public string ImgPerfil
        {
            get
            {
                return _imgPerfil;
            }

            set
            {
                _imgPerfil = value;
            }
        }

        public bool Admin
        {
            get
            {
                return _admin;
            }

            set
            {
                _admin = value;
            }
        }

    }
}
  
