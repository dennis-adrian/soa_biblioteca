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
        public Libros ActualizarLibro(Libros libro)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                
                try
                {
                    var parametro = new DynamicParameters();
                    //"pIdSupplier" corresponde al nombre que tiene el id en nuestro sp de la BD, "id" es el dato que pasaremos en este metodo 
                    parametro.Add("@pIdLibro", libro.id_libro);
                    parametro.Add("@pNombreLibro", libro.libro_nombre);
                    parametro.Add("@pIsbnLibro", libro.libro_isbn);
                    parametro.Add("@pPublicacion", libro.libro_anio_publicacion);
                    parametro.Add("@pNombreAutor", libro.autor_nombre);
                    parametro.Add("@pNombreGenero", libro.genero_nombre);

                    //aqui entra en ejecucion el ORM
                    var resultado = conexion.Execute("dbo.sp_libros_actualizar", param: parametro, commandType: CommandType.StoredProcedure);

                    return resultado > 0 ? libro : new Libros();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool EliminarLibro(string id_libro)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();

                try
                {
                    var parametro = new DynamicParameters();

                    //"pIdSupplier" corresponde al nombre que tiene el id en nuestro sp de la BD, "id" es el dato que pasaremos en este metodo 
                    parametro.Add("@pIdLibro", id_libro);

                    //aqui entra en ejecucion el ORM
                    var resultado = conexion.Execute("dbo.sp_libros_eliminar", param: parametro, commandType: CommandType.StoredProcedure);

                    return resultado > 0;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public Libros InsertarLibro(Libros libro)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();

                try
                {
                    var parametro = new DynamicParameters();

                    //"pIdSupplier" corresponde al nombre que tiene el id en nuestro sp de la BD, "id" es el dato que pasaremos en este metodo 
                    parametro.Add("@pNombreLibro", libro.libro_nombre);
                    parametro.Add("@pIsbnLibro", libro.libro_isbn);
                    parametro.Add("@pPublicacion", libro.libro_anio_publicacion);
                    parametro.Add("@pNombreAutor", libro.autor_nombre);
                    parametro.Add("@pNombreGenero", libro.genero_nombre);
                    parametro.Add("@pIdLibro", libro.id_libro, DbType.Int32, ParameterDirection.Output);

                    //aqui entra en ejecucion el ORM
                    var resultado = conexion.ExecuteScalar("dbo.sp_libros_insertar", param: parametro, commandType: CommandType.StoredProcedure);

                    var LibroId = parametro.Get<Int32>("@pIdLibro");

                    libro.id_libro = LibroId;

                    return libro;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public IEnumerable<Libros> ListarLibros()
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();

                try
                {
                    //aqui entra en ejecucion el ORM
                    var libros = conexion.Query<Libros>("dbo.sp_libros_listar", commandType: CommandType.StoredProcedure);

                    return libros;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public Libros ObtenerLibroPorId(string id_libro)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();

                try
                {
                    var parametro = new DynamicParameters();

                    //"pIdSupplier" corresponde al nombre que tiene el id en nuestro sp de la BD, "id" es el dato que pasaremos en este metodo 
                    parametro.Add("@pIdLibro", id_libro);

                    //aqui entra en ejecucion el ORM
                    var libro = conexion.QuerySingleOrDefault<Libros>("dbo.sp_libros_obtener_por_id", param: parametro, commandType: CommandType.StoredProcedure);

                    return libro;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public Libros ObtenerLibroPorNombre(string libro_nombre)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();

                try
                {
                    var parametro = new DynamicParameters();

                    //"pIdSupplier" corresponde al nombre que tiene el id en nuestro sp de la BD, "id" es el dato que pasaremos en este metodo 
                    parametro.Add("@pNombreLibro", libro_nombre);

                    //aqui entra en ejecucion el ORM
                    var libro = conexion.QuerySingleOrDefault<Libros>("dbo.sp_libros_obtener_por_nombre", param: parametro, commandType: CommandType.StoredProcedure);

                    return libro;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
