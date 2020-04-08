using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAP4.Biblioteca.Dominio;
using DAP4.Biblioteca.ContratoRepositorio;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DAP4.Biblioteca.SqlRepositorio
{
    public class GenerosRepositorio : IGenerosRepositorio
    {
        public Generos ActualizarGenero(Generos genero)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();

                parametros.Add("@pIdGenero", genero.id_genero);
                parametros.Add("@pNombreGenero", genero.genero_nombre);

                var resultado = conexion.Execute("dbo.sp_generos_actualizar", param: parametros, commandType: CommandType.StoredProcedure);

                return resultado > 0 ? genero : new Generos();
            }
        }

        public bool EliminarGenero(string id_genero)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();
                parametros.Add("@pIdGenero", id_genero);

                var resultado = conexion.Execute("dbo.sp_generos_eliminar", param: parametros, commandType: CommandType.StoredProcedure);

                return resultado > 0;
            }
        }

        public Generos InsertarGenero(Generos genero)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();

                parametros.Add("@pNombreGenero", genero.genero_nombre);
                parametros.Add("@pIdGenero", genero.id_genero, DbType.Int32, ParameterDirection.Output);

                var resultado = conexion.ExecuteScalar("dbo.sp_generos_insertar", param: parametros, commandType: CommandType.StoredProcedure);

                var GeneroId = parametros.Get<Int32>("@pIdGenero");

                genero.id_genero = GeneroId;

                return genero;
            }
        }

        public IEnumerable<Generos> ListarGeneros()
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();

                var coleccion = conexion.Query<Generos>("dbo.sp_generos_listar", commandType: CommandType.StoredProcedure);

                return coleccion;
            }
        }
    }
}
