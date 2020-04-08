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
    public class AutoresRepositorio : IAutoresRepositorio
    {
        public Autores ActualizarAutor(Autores autor)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();

                parametros.Add("@pIdAutor", autor.id_autor);
                parametros.Add("@pNombreAutor", autor.autor_nombre);
                parametros.Add("@pPais", autor.autor_pais);

                var resultado = conexion.Execute("dbo.sp_autores_actualizar", param: parametros, commandType: CommandType.StoredProcedure);

                return resultado > 0 ? autor : new Autores();
            }
        }

        public bool EliminarAutor(string id_autor)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();
                parametros.Add("@pIdAutor", id_autor);

                var resultado = conexion.Execute("dbo.sp_autores_eliminar", param: parametros, commandType: CommandType.StoredProcedure);

                return resultado > 0;
            }
        }

        public Autores InsertarAutor(Autores autor)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();

                parametros.Add("@pNombreAutor", autor.autor_nombre);
                parametros.Add("@pPais", autor.autor_pais);
                parametros.Add("@pIdAutor", autor.id_autor, DbType.Int32, ParameterDirection.Output);

                var resultado = conexion.ExecuteScalar("dbo.sp_autores_insertar", param: parametros, commandType: CommandType.StoredProcedure);

                var AutorId = parametros.Get<Int32>("@pIdAutor");

                autor.id_autor = AutorId;

                return autor;
            }
        }

        public IEnumerable<Autores> ListarAutores()
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();

                var coleccion = conexion.Query<Autores>("dbo.sp_autores_listar", commandType: CommandType.StoredProcedure);

                return coleccion;
            }
        }

        public Autores ObtenerAutorPorId(string id_autor)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();

                try
                {
                    var parametro = new DynamicParameters();

                    //"pIdAutor" corresponde al nombre que tiene el id en nuestro sp de la BD, "id" es el dato que pasaremos en este metodo 
                    parametro.Add("@pIdAutor", id_autor);

                    //aqui entra en ejecucion el ORM
                    var autor = conexion.QuerySingleOrDefault<Autores>("dbo.autores_obtener_por_id", param: parametro, commandType: CommandType.StoredProcedure);

                    return autor;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public Autores ObtenerAutorPorNombre(string nombre_autor)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();

                try
                {
                    var parametro = new DynamicParameters();

                    //"pIdSupplier" corresponde al nombre que tiene el id en nuestro sp de la BD, "id" es el dato que pasaremos en este metodo 
                    parametro.Add("@pNombreAutor", nombre_autor);

                    //aqui entra en ejecucion el ORM
                    var autor = conexion.QueryFirstOrDefault<Autores>("dbo.sp_autores_obtener_por_nombre", param: parametro, commandType: CommandType.StoredProcedure);

                    return autor;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
