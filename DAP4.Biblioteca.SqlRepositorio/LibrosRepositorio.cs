using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAP4.Biblioteca.Dominio;
using DAP4.Biblioteca.ContratoRepositorio;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DAP4.Biblioteca.SqlRepositorio
{
    public class LibrosRepositorio: ILibrosRepositorio
    {
        public IEnumerable<Libros> ListarLibros()
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();

                //aqui entra en ejecucion el ORM
                var libros = conexion.Query<Libros>("dbo.sp_libros_listar", commandType: CommandType.StoredProcedure);

                return libros;
            }
        }

        public Libros ObtenerLibroPorId(int id_libro)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametro = new DynamicParameters();

                //"pIdSupplier" corresponde al nombre que tiene el id en nuestro sp de la BD, "id" es el dato que pasaremos en este metodo 
                parametro.Add("@pIdLibro", id_libro);

                //aqui entra en ejecucion el ORM
                var libro = conexion.QuerySingle<Libros>("dbo.sp_libros_obtener_por_id", param: parametro, commandType: CommandType.StoredProcedure);

                return libro;
            }
        }

        public Libros ObtenerLibroPorNombre(string libro_nombre)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametro = new DynamicParameters();

                //"pIdSupplier" corresponde al nombre que tiene el id en nuestro sp de la BD, "id" es el dato que pasaremos en este metodo 
                parametro.Add("@@pNombreLibro", libro_nombre);

                //aqui entra en ejecucion el ORM
                var libro = conexion.QuerySingle<Libros>("dbo.sp_libros_obtener_por_nombre", param: parametro, commandType: CommandType.StoredProcedure);

                return libro;
            }
        }
    }
}
