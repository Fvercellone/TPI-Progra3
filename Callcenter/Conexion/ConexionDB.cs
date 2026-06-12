using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Conexion
{
    public class ConexionDB
    {
        private SqlConnection _Conexion;
        private SqlCommand _Comando;
        private SqlDataReader _Lector;

        public SqlDataReader _lector
        { get { return _Lector; } }

        public ConexionDB()
        {
            _Conexion = new SqlConnection("server=localhost,14330; database=TPI_Progra3_DB; user=sa; password=Miriam27/10");
            _Conexion = new SqlConnection("server=.\\SQLEXPRESS; database=TPI_Progra3; integrated security=true");
            _Comando = new SqlCommand();
            _Comando.Connection = _Conexion;
        }

        public void settearConsulta(string consulta)
        {
            _Comando.CommandType = System.Data.CommandType.Text;
            _Comando.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            try
            {
                _Conexion.Open();
                _Lector = _Comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ejecutarAccion()
        {
            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void agregarParametro(string nombre, object valor)
        {
            _Comando.Parameters.AddWithValue(nombre, valor);
        }

        public void cerrarConexion()
        {
            if (_Lector != null)
                _Lector.Close();
            _Conexion.Close();

        }
    }
}
