using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Data.SqlClient;

namespace QEQ2.Models
{
    public class BD
    {
        public static string connectionString = "Server=10.128.8.16;Database=QEQB08;User Id=QEQB08; Password=QEQB08;";

        private static SqlConnection Conectar()
        {
            SqlConnection a = new SqlConnection(connectionString);
            a.Open();
            return a;
        }

        public static void Desconectar(SqlConnection conexion)
        {
            conexion.Close();
        }

        public static bool Registro(Usuarios U)
        {
            bool a = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.CommandText = "sp_RegistrarUsuarios";
            consulta.Parameters.AddWithValue("@pUsuario", U.Nombre);
            consulta.Parameters.AddWithValue("@pContraseña", U.Contraseña);
            consulta.Parameters.AddWithValue("@pImagen", U.ImgPerfil);
            int regsAfectados = consulta.ExecuteNonQuery();
            
            if (regsAfectados == 1)
            {
                a = true;
            }
            Desconectar(Conexion);
            return a;
        }
        public static bool Login (string Nombre, string Contraseña)
        {
            bool a = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.CommandText = "sp_LogIn";
            consulta.Parameters.AddWithValue("@pNombre", Nombre);
            consulta.Parameters.AddWithValue("@pContraseña", Contraseña);
            SqlDataReader lector = consulta.ExecuteReader();
            while(lector.Read())
            {
                a = true;
            }

            Desconectar(Conexion);
            return a;
            
        }
        public static bool OtroLogin(string Nombre, string Contraseña)
        {
            bool a = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.CommandText = "sp_OtroLogin";
            consulta.Parameters.AddWithValue("@pNombre", Nombre);
            consulta.Parameters.AddWithValue("@pContraseña", Contraseña);
            SqlDataReader lector = consulta.ExecuteReader();
            while (lector.Read())
            {
                a = true;
            }
            Desconectar(Conexion);
            return a;
        }
    }      
}
