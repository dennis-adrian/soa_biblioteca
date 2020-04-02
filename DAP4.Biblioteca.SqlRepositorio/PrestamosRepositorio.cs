using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAP4.Biblioteca.ContratoRepositorio;
using DAP4.Biblioteca.Dominio;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DAP4.Biblioteca.SqlRepositorio
{
    public class PrestamosRepositorio : IPrestamosRepositorio
    {
        public Prestamos ActualizarPrestamo(Prestamos prestamo)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();

                parametros.Add("@pIdPrestamo", prestamo.id_prestamo);
                parametros.Add("@pCodigoPrestamo", prestamo.prestamo_codigo);
                parametros.Add("@pNombreLibro", prestamo.libro_nombre);
                parametros.Add("@pApellidoCliente", prestamo.cliente_apellido);
                parametros.Add("@pNombreCliente", prestamo.cliente_nombre);

                var resultado = conexion.Execute("dbo.sp_prestamos_actualizar", param: parametros, commandType: CommandType.StoredProcedure);

                return resultado > 0 ? prestamo : new Prestamos();
            }
        }

        public bool DevolverPrestamo(string id_prestamo)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();
                parametros.Add("@pIdPrestamo", id_prestamo);

                var resultado = conexion.Execute("dbo.sp_prestamos_devolver", param: parametros, commandType: CommandType.StoredProcedure);

                return resultado > 0;
            }
        }

        public Prestamos InsertarPrestamo(Prestamos prestamo)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();

                parametros.Add("@pCodigoPrestamo", prestamo.prestamo_codigo);
                parametros.Add("@pNombreLibro", prestamo.libro_nombre);
                parametros.Add("@pApellidoCliente", prestamo.cliente_apellido);
                parametros.Add("@pNombreCliente", prestamo.cliente_nombre);
                parametros.Add("@pIdEmpleado", prestamo.id_empleado);
                parametros.Add("@pIdPrestamo", prestamo.id_prestamo, DbType.Int32, ParameterDirection.Output);

                var resultado = conexion.ExecuteScalar("dbo.sp_prestamos_insertar", param: parametros, commandType: CommandType.StoredProcedure);

                var PrestamoId = parametros.Get<Int32>("@pIdPrestamo");

                prestamo.id_prestamo= PrestamoId;

                return prestamo;
            }
        }

        public IEnumerable<Prestamos> ListarPrestamos()
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();

                var coleccion = conexion.Query<Prestamos>("dbo.sp_prestamos_listar", commandType: CommandType.StoredProcedure);

                return coleccion;
            }
        }

        public Prestamos ObtenerPrestamoPorCodigo(string codigo_prestamo)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();

                var parametros = new DynamicParameters();

                parametros.Add("@pCodigoPrestamo", codigo_prestamo);

                var prestamo = conexion.QueryFirst<Prestamos>("dbo.sp_prestamos_obtener_por_codigo", param: parametros, commandType: CommandType.StoredProcedure);

                return prestamo;
            }
        }
    }
}
