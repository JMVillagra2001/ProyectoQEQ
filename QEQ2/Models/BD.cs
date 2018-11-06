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
        public static bool Login (Usuarios x)
        {
            bool a = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.CommandText = "sp_LogIn";
            consulta.Parameters.AddWithValue("@pNombre", x.Nombre);
            consulta.Parameters.AddWithValue("@pContraseña", x.Contraseña);
            SqlDataReader lector = consulta.ExecuteReader();
            while(lector.Read())
            {
                a = true;
            }

            Desconectar(Conexion);
            return a;
            
        }
        public static bool OtroLogin(Usuarios x)
        {
            bool a = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.CommandText = "sp_OtroLogin";
            consulta.Parameters.AddWithValue("@pNombre", x.Nombre);
            consulta.Parameters.AddWithValue("@pContraseña", x.Contraseña);
            SqlDataReader lector = consulta.ExecuteReader();
            while (lector.Read())
            {
                a = true;
            }
            Desconectar(Conexion);
            return a;
        }
        public static Categoria TraerCategoria (int x)
        {
            Categoria unacategoria = new Categoria();
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.CommandText = "sp_VerCategoria";
            consulta.Parameters.AddWithValue("@pidCategoria", x);
            SqlDataReader lector = consulta.ExecuteReader();
            if (lector.Read())
            {
                string  Nombre;
                Nombre = lector["Nombre"].ToString();
            }
            return unacategoria;
        }
        public static bool InsertarCategoria(Categoria C)
        {
            bool a = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.CommandText = "sp_CrearCategoria";
            consulta.Parameters.AddWithValue("@pUsuario", C.Nombre);
            int regsAfectados = consulta.ExecuteNonQuery();
            if (regsAfectados == 1)
            {
                a = true;
            }
            Desconectar(Conexion);
            return a;
        }
        public void TraerUsuario(Categoria x)//crear sp
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.CommandText = "sp_TraerUsuario";
            SqlDataReader lector = consulta.ExecuteReader();
            while (lector.Read())
            {
                string Nombre;
                Nombre = lector["Nombre"].ToString();
            }
        }
        public void TraerPreguntas(Preguntas P)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.CommandText = "sp_ListarPreguntas";
            SqlDataReader lector = consulta.ExecuteReader();
            while (lector.Read())
            {
                string Nombre;
                Nombre = lector["Nombre"].ToString();
            }
        }
        public static bool InsertarPreguntas(Preguntas P)
        {
            bool a = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.CommandText = "sp_CrearPregunta";
            consulta.Parameters.AddWithValue("@pPregunta", P.Texto);
            consulta.Parameters.AddWithValue("@pCatPreg", P.IdCategoria);
            int regsAfectados = consulta.ExecuteNonQuery();
            if (regsAfectados == 1)
            {
                a = true;
            }
            Desconectar(Conexion);
            return a;
        }

        public static bool InsertarPersonajes(Personajes P)
        {
            bool a = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.CommandText = "sp_CrearPersonaje";
            consulta.Parameters.AddWithValue("@pNombre", P.Nombre);
            consulta.Parameters.AddWithValue("@pCatPreg", P.Categoria);
            int regsAfectados = consulta.ExecuteNonQuery();
            if (regsAfectados == 1)
            {
                a = true;
            }
            Desconectar(Conexion);
            return a;
        }
        public static List<Categoria> TraerCategorias()
        {
            List<Categoria> C = new List<Categoria>();
            Categoria cat;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.CommandText = "VerCategoria";
            SqlDataReader lector = consulta.ExecuteReader();
            while (lector.Read())
            {
                cat = new Categoria();
                cat.IdCategoria = Convert.ToInt32(lector["IdCategoría"]);
                cat.Nombre = lector["Nombre"].ToString();
                C.Add(cat);
            }
            Desconectar(Conexion);
            return C;
        }
        public static bool EliminarCategorias(Categoria P)
        {
            bool a = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.CommandText = "EliminarCategoria";
            consulta.Parameters.AddWithValue("@pIdCategoria", P.IdCategoria);
            int lector = consulta.ExecuteNonQuery();
            if (lector == 1)
            {
                a = true;
            }
            Desconectar(Conexion);
            return a;
        }
    }      
}
