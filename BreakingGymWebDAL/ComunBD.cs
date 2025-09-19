using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakingGymWebDAL
{
    public  class ComunBD
    {
        public enum TipoBD
        {
            SqlServer, Oracle, DB2
        }
        public const string Sqlconn = @"Data Source=DAVID-24\SQLEXPRESS;Initial Catalog=BreakingGymWeb;Integrated Security=True;Trust Server Certificate=True;";
        public static IDbConnection ObtenerConexion(TipoBD pTipoBD)
        {
            IDbConnection _conn;
            if (pTipoBD == TipoBD.SqlServer)
            {
                _conn = new SqlConnection(Sqlconn);
                return _conn;
            }
            return null;
        }
    }
}
