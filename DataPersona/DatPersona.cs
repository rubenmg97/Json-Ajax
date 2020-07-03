using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TiDev.Data.Persona
{
    public class DatPersona
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Sql"].ConnectionString);

        public DataTable Obtener()
        {
            SqlCommand comando = new SqlCommand("spObtenerPersonas", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        public DataRow Obtener(int id)
        {
            SqlCommand comando = new SqlCommand("spObtenerPersonasId", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla.Rows[0];
        }

        public DataTable Obtener(String nombre)
        {
            SqlCommand comando = new SqlCommand("spObtenerPersonasNombre", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            return tabla;
        }

        public Boolean Obtener(String nombre, String paterno, String materno)
        {
            SqlCommand comando = new SqlCommand("spObtenerPersonasNombreCompleto", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Paterno", paterno);
            comando.Parameters.AddWithValue("@Materno", materno);
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            if (tabla.Rows[0] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Delete(int id)
        {
            int filasAfectadas = 0;
            SqlCommand comando = new SqlCommand("spBorrarPersona", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", id);

            try
            {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
                return filasAfectadas;
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }

        public int Edit(int id, String nombre, String paterno, String materno, DateTime nacimiento, Boolean sexo)
        {
            int filasAfectadas = 0;
            SqlCommand comando = new SqlCommand("spEditarPersona", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", id);
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Paterno", paterno);
            comando.Parameters.AddWithValue("@Materno", materno);
            comando.Parameters.AddWithValue("@FechaNacimiento", nacimiento);
            comando.Parameters.AddWithValue("@Sexo", sexo);

            try
            {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
                return filasAfectadas;
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }

        public int Create(String nombre, String paterno, String materno, DateTime nacimiento, Boolean sexo)
        {
            int filasAfectadas = 0;
            SqlCommand comando = new SqlCommand("spCrearPersona", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Paterno", paterno);
            comando.Parameters.AddWithValue("@Materno", materno);
            comando.Parameters.AddWithValue("@Sexo", sexo);
            comando.Parameters.AddWithValue("@FechaNacimiento", nacimiento);

            try
            {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
                return filasAfectadas;
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }


    }
}
