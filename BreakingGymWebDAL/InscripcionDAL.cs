using BreakingGymWebEN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace BreakingGymWebDAL
{
    public class InscripcionDAL
    {
        public static List<InscripcionEN> BuscarInscripcion(string celular)
        {
            List<InscripcionEN> lista = new List<InscripcionEN>();

            using (IDbConnection conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                conn.Open();
                SqlCommand comando = new SqlCommand("BuscarInscripcionPorCelular", conn as SqlConnection);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@Celular",
                    string.IsNullOrEmpty(celular) ? (object)DBNull.Value : celular));

                IDataReader _reader = comando.ExecuteReader();
                while (_reader.Read())
                {
                    lista.Add(new InscripcionEN
                    {
                        Id = _reader.GetInt32(0),
                        IdUsuario = _reader.GetInt32(1),
                        Nombre_Usuario = _reader.GetString(2),
                        Apellido_Usuario= _reader.GetString(3),
                        Celular = _reader.GetString(4),
                        IdMembresia = _reader.GetInt32(5),
                        Nombre_Membresia = _reader.GetString(6),
                        IdEstado = _reader.GetInt32(7),
                        Nombre_Estado = _reader.GetString(8),
                        FechaInscripcion = _reader.GetDateTime(9),
                        FechaVencimiento = _reader.GetDateTime(10)

                    });
                }
                conn.Close();
            }

            return lista;
        }
        public static List<InscripcionEN> MostrarInscripcion()
        {
            List<InscripcionEN> _Lista = new List<InscripcionEN>();
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("MostrarInscripcionNombre", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                IDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    _Lista.Add(new InscripcionEN
                    {
                        Id = _reader.GetInt32(0),
                        IdUsuario = _reader.GetInt32(1),
                        Nombre_Usuario = _reader.GetString(2),
                        Apellido_Usuario= _reader.GetString(3),
                        Celular = _reader.GetString(4),
                        IdMembresia = _reader.GetInt32(5),
                        Nombre_Membresia = _reader.GetString(6),
                        IdEstado = _reader.GetInt32(7),
                        Nombre_Estado = _reader.GetString(8),
                        FechaInscripcion = _reader.GetDateTime(9),
                        FechaVencimiento = _reader.GetDateTime(10)
                    });
                }
                _conn.Close();
            }
            return _Lista;
        }
      
        public static int AgregarInscripcion(InscripcionEN pinscripcionEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("GuardarInscripcion", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@IdUsuario", pinscripcionEN.IdUsuario));
                _comando.Parameters.Add(new SqlParameter("@IdMembresia", pinscripcionEN.IdMembresia));
                _comando.Parameters.Add(new SqlParameter("@IdEstado", pinscripcionEN.IdEstado));
                _comando.Parameters.Add(new SqlParameter("@FechaInscripcion",
                    (object?)pinscripcionEN.FechaInscripcion ?? DBNull.Value));
                _comando.Parameters.Add(new SqlParameter("@FechaVencimiento",
                    (object?)pinscripcionEN.FechaVencimiento ?? DBNull.Value));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }

        public static int EliminarInscripcion(int Id)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("EliminarInscripcion", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", Id));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }

        public static int ModificarInscripcion(InscripcionEN pinscripcionEN)
        {
            using (IDbConnection _conn = ComunBD.ObtenerConexion(ComunBD.TipoBD.SqlServer))
            {
                _conn.Open();
                SqlCommand _comando = new SqlCommand("ModificarInscripcion", _conn as SqlConnection);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.Parameters.Add(new SqlParameter("@Id", pinscripcionEN.Id));
                _comando.Parameters.Add(new SqlParameter("@IdUsuario", pinscripcionEN.IdUsuario));
                _comando.Parameters.Add(new SqlParameter("@IdMembresia", pinscripcionEN.IdMembresia));
                _comando.Parameters.Add(new SqlParameter("@IdEstado", pinscripcionEN.IdEstado));
                _comando.Parameters.Add(new SqlParameter("@FechaInscripcion",
                    (object?)pinscripcionEN.FechaInscripcion ?? DBNull.Value));
                _comando.Parameters.Add(new SqlParameter("@FechaVencimiento",
                    (object?)pinscripcionEN.FechaVencimiento ?? DBNull.Value));
                int resultado = _comando.ExecuteNonQuery();
                _conn.Close();
                return resultado;
            }
        }
    }
}
