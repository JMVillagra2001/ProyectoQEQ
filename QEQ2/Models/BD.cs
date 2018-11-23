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
        public static bool Login(Usuarios x)
        {
            bool a = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.CommandText = "sp_LogIn";
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
        public static Categoria TraerCategoria(int x)
        {
            Categoria unacategoria = new Categoria();
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.CommandText = "TraerCategoria";
            consulta.Parameters.AddWithValue("@pIdCategoria", x);
            SqlDataReader lector = consulta.ExecuteReader();
            if (lector.Read())
            {
                string Nombre;
                Nombre = lector["Nombre"].ToString();
                unacategoria.Nombre = lector["Nombre"].ToString();
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
        public void TraerUsuario(Categoria x)
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
            consulta.CommandText = "CrearPersonaje";
            consulta.Parameters.AddWithValue("@Nombre", P.Nombre);
            consulta.Parameters.AddWithValue("@Categoria", P.Categoria);
            consulta.Parameters.AddWithValue("@Imagen", P.Imagen);
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
                cat.IdCategoria = Convert.ToInt32(lector["idCategoría"]);
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
            consulta.Parameters.AddWithValue("@IdCategoria", P.IdCategoria);
            consulta.CommandText = "EliminarCategoria";
            int lector = consulta.ExecuteNonQuery();
            if (lector == 1)
            {
                a = true;
            }
            Desconectar(Conexion);
            return a;
        }
        public static bool ModificarCategoria(Categoria P)
        {
            bool a = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@IdCategoria", P.IdCategoria);
            consulta.Parameters.AddWithValue("@categoria", P.Nombre);
            consulta.CommandText = "ModificarCategoria";
            int lector = consulta.ExecuteNonQuery();
            if (lector == 1)
            {
                a = true;
            }
            Desconectar(Conexion);
            return a;
        }
        public static bool CrearCategoria(Categoria P)
        {
            bool a = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@Categoria", P.Nombre);
            consulta.CommandText = "CrearCategoria";
            int lector = consulta.ExecuteNonQuery();
            if (lector == 1)
            {
                a = true;
            }
            Desconectar(Conexion);
            return a;
        }
        public static Preguntas TraerPregunta(int Id)
        {
            Preguntas unacategoria = new Preguntas();
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.CommandText = "sp_TraerPregunta";
            consulta.Parameters.AddWithValue("@pIdPregunta", Id);
            SqlDataReader lector = consulta.ExecuteReader();
            if (lector.Read())
            {
                string Texto;
                Texto = lector["Texto"].ToString();
                unacategoria.Texto = lector["Texto"].ToString();
            }
            return unacategoria;
        }

        public static List<Preguntas> TraerPreguntas(Preguntas P)
        {
            List<Preguntas> C = new List<Preguntas>();
            Preguntas cat;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.CommandText = "sp_VerPreguntas";
            SqlDataReader lector = consulta.ExecuteReader();
            while (lector.Read())
            {
                cat = new Preguntas();
                cat.IdPregunta = Convert.ToInt32(lector["IdPregunta"]);
                cat.Texto = lector["Texto"].ToString();
                cat.IdCategoria = Convert.ToInt32(lector["IdCateggoria"]);
                C.Add(cat);
            }
            Desconectar(Conexion);
            return C;
        }
        public static bool EliminarPreguntas(int IdPregunta)
        {
            bool a = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@idPreg", IdPregunta);
            consulta.CommandText = "EliminarPregunta";
            int lector = consulta.ExecuteNonQuery();
            if (lector == 1)
            {
                a = true;
            }
            Desconectar(Conexion);
            return a;
        }
        public static bool ModificarPreguntas(int IdPregunta, string Texto)
        {
            bool a = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@IdPreguntas", IdPregunta);
            consulta.Parameters.AddWithValue("@Pregunta", Texto);
            consulta.CommandText = "ModificarPregunta";
            int lector = consulta.ExecuteNonQuery();
            if (lector == 1)
            {
                a = true;
            }
            Desconectar(Conexion);
            return a;
        }
        public static bool CrearPregunta(int IdCategoria, string Texto)
        {
            bool a = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@CatPreg", IdCategoria);
            consulta.Parameters.AddWithValue("@Pregunta", Texto);
            consulta.CommandText = "CrearPregunta";
            int lector = consulta.ExecuteNonQuery();
            if (lector == 1)
            {
                a = true;
            }
            Desconectar(Conexion);
            return a;
        }
        public static List<Personajes> TraerPersonaje(Personajes x)
        {
            List<Personajes> C = new List<Personajes>();
            Personajes cat;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.CommandText = "VerPersonajes";
            SqlDataReader lector = consulta.ExecuteReader();
            while (lector.Read())
            {
                cat = new Personajes();
                cat.Nombre = lector["Nombre"].ToString();
                cat.Categoria = Convert.ToInt32(lector["idCategoría"]);
                cat.IdPersonaje = Convert.ToInt32(lector["IdPersonaje"]);
                cat.Imagen = lector["Imagen"].ToString();
                C.Add(cat);
            }
            Desconectar(Conexion);
            return C;
        }
        public static Personajes TraerPersonajes(int Id)
        {
            Personajes unacategoria = new Personajes();
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.CommandText = "sp_TraerPersonaje";
            consulta.Parameters.AddWithValue("@idPersonaje", Id);
            SqlDataReader lector = consulta.ExecuteReader();
            if (lector.Read())
            {
                string Nombre;
                Nombre = lector["Nombre"].ToString();
                unacategoria.Nombre = lector["Nombre"].ToString();
            }
            return unacategoria;
        }
        public static bool EliminarPersonajes(int IdPersonaje)
        {
            bool a = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@IdPersonaje", IdPersonaje);
            consulta.CommandText = "EliminarPersonaje";
            int lector = consulta.ExecuteNonQuery();
            if (lector == 1)
            {
                a = true;
            }
            Desconectar(Conexion);
            return a;
        }
        public static bool ModificarPersonajes(Personajes P)
        {
            bool a = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@IdPersonaje", P.IdPersonaje);
            consulta.Parameters.AddWithValue("@Nombre", P.Nombre);
            consulta.Parameters.AddWithValue("@Categoria", P.Categoria);
            consulta.Parameters.AddWithValue("@Imagen", P.Imagen);
            consulta.CommandText = "ModificarPersonaje";
            int lector = consulta.ExecuteNonQuery();
            if (lector == 1)
            {
                a = true;
            }
            Desconectar(Conexion);
            return a;
        }
        public static bool InsertarPreguntasXpersonajes(int[] tCate, int IdPersonaje)
        {
            SqlConnection Conexion = Conectar();
            bool a = false;
            foreach (int cat in tCate)
            {
                SqlCommand consulta = Conexion.CreateCommand();
                consulta.CommandType = System.Data.CommandType.StoredProcedure;
                consulta.CommandText = "sp_AsociarPreguntaXPersonaje";
                consulta.Parameters.AddWithValue("@idPersonaje", IdPersonaje);
                consulta.Parameters.AddWithValue("@idPregunta", cat);
                int regsAfectados = consulta.ExecuteNonQuery();
                if (regsAfectados == 1)
                {
                    a = true;
                }
            }

            Desconectar(Conexion);
            return a;
        }
        public static List<PreguntasXpersonaje> PreguntasxPersonaje(int IdPersonaje)
        {
            List<PreguntasXpersonaje> ListaPersonjaes = new List<PreguntasXpersonaje>();
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_TraerPersonajePorPregSel";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@id_Personaje", IdPersonaje);
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int IdPersonajes = Convert.ToInt32(dataReader["idPersonajes"]);
                int IdPreguntas = Convert.ToInt32(dataReader["idPregunta"]);
                PreguntasXpersonaje P = new PreguntasXpersonaje(IdPersonajes, IdPreguntas);
                ListaPersonjaes.Add(P);
            }
            Desconectar(conexion);
            return ListaPersonjaes;
        }
    }
}

