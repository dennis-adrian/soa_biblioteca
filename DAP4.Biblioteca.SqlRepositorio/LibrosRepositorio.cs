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
        public Libros ActualizarLibro(int id_libro, string libro_nombre, string libro_isbn, int anio_publicacion, string autor_nombre, string genero_nombre)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                
                try
                {
                    var parametro = new DynamicParameters();
                    //"pIdSupplier" corresponde al nombre que tiene el id en nuestro sp de la BD, "id" es el dato que pasaremos en este metodo 
                    parametro.Add("@pIdLibro", id_libro);
                    parametro.Add("@pNombreLibro", libro_nombre);
                    parametro.Add("@pIsbnLibro", libro_isbn);
                    parametro.Add("@pPublicacion", anio_publicacion);
                    parametro.Add("@pNombreAutor", autor_nombre);
                    parametro.Add("@pNombreGenero", genero_nombre);

                    //aqui entra en ejecucion el ORM
                    var libro = conexion.QuerySingleOrDefault<Libros>("dbo.sp_libros_actualizar", param: parametro, commandType: CommandType.StoredProcedure);

                    return libro;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public Libros EliminarLibro(int id_libro)
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
                    var libro = conexion.QuerySingleOrDefault<Libros>("dbo.sp_libros_eliminar", param: parametro, commandType: CommandType.StoredProcedure);

                    return libro;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void InsertarLibro(string libro_nombre, string libro_isbn, int anio_publicacion, string autor_nombre, string genero_nombre)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();

                try
                {
                    var parametro = new DynamicParameters();

                    //"pIdSupplier" corresponde al nombre que tiene el id en nuestro sp de la BD, "id" es el dato que pasaremos en este metodo 
                    parametro.Add("@pNombreLibro", libro_nombre);
                    parametro.Add("@pIsbnLibro", libro_isbn);
                    parametro.Add("@pPublicacion", anio_publicacion);
                    parametro.Add("@pNombreAutor", autor_nombre);
                    parametro.Add("@pNombreGenero", genero_nombre);

                    //aqui entra en ejecucion el ORM
                    conexion.QuerySingleOrDefault<Libros>("dbo.sp_libros_insertar", param: parametro, commandType: CommandType.StoredProcedure);
                }
                catch (Exception)
                {
                    throw;
                }

                //string insertQuery = @"INSERT INTO [dbo].[Libros]([libro_nombre], [libro_isbn], [libro_anio_publicacion], [id_autor], [id_genero]) VALUES (@libro_nombre, @libro_isbn, @anio_publicacion, @id_autor, @id_genero)";

                //var result = conexion.Execute(insertQuery, new
                //{
                //    tarea,
                //    id_libro,
                //    libro_nombre,
                //    libro_isbn,
                //    anio_publicacion,
                //    id_autor,
                //    id_genero
                //});
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

        public Libros ObtenerLibroPorId(int id_libro)
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
