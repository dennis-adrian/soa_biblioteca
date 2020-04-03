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
    public class EmpleadosRepositorio : IEmpleadosRepositorio
    {
        public Empleados ActualizarEmpleado(Empleados empleado)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();

                parametros.Add("@pIdEmpleado", empleado.id_empleado);
                parametros.Add("@pNombreEmpleado", empleado.empleado_nombre);
                parametros.Add("@pApellidoEmpleado", empleado.empleado_apellido);
                parametros.Add("@pCargoEmpleado", empleado.empleado_cargo);
                parametros.Add("@pFechaNacimientoEmpleado", empleado.empleado_fecha_nac);
                parametros.Add("@pTelefonoEmpleado", empleado.empleado_telefono);
                parametros.Add("@pEmailEmpleado", empleado.empleado_email);

                var resultado = conexion.Execute("dbo.sp_empleados_actualizar", param: parametros, commandType: CommandType.StoredProcedure);

                return resultado > 0 ? empleado : new Empleados();
            }
        }

        public bool EliminarEmpleado(string id)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();
                parametros.Add("@pIdEmpleados", id);

                var resultado = conexion.Execute("dbo.sp_empleados_eliminar", param: parametros, commandType: CommandType.StoredProcedure);

                return resultado > 0;
            }
        }

        public Empleados InsertarEmpleados(Empleados empleado)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();

                parametros.Add("@pNombreEmpleado", empleado.empleado_nombre);
                parametros.Add("@pApellidoEmpleado", empleado.empleado_apellido);
                parametros.Add("@pCargoEmpleado", empleado.empleado_cargo);
                parametros.Add("@pFechaNacimientoEmpleado", empleado.empleado_fecha_nac);
                parametros.Add("@pTelefonoEmpleado", empleado.empleado_telefono);
                parametros.Add("@pEmailEmpleado", empleado.empleado_email);
                parametros.Add("@pIdEmpleado", empleado.id_empleado, DbType.Int32, ParameterDirection.Output);

                var resultado = conexion.ExecuteScalar("dbo.sp_empleados_insertar", param: parametros, commandType: CommandType.StoredProcedure);

                var EmpleadoId = parametros.Get<Int32>("@pIdEmpleado");

                empleado.id_empleado = EmpleadoId;

                return empleado;
            }
        }

        public IEnumerable<Empleados> ListarEmpleados()
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();

                var coleccion = conexion.Query<Empleados>("dbo.sp_empleados_listar", commandType: CommandType.StoredProcedure);

                return coleccion;
            }
        }

        public Empleados ObtenerEmpleadosPorApellido(string apellido)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();

                try
                {
                    var parametro = new DynamicParameters();

                    //"pIdSupplier" corresponde al nombre que tiene el id en nuestro sp de la BD, "id" es el dato que pasaremos en este metodo 
                    parametro.Add("@pApellidoEmpleado", apellido);

                    //aqui entra en ejecucion el ORM
                    var empleado = conexion.QueryFirstOrDefault<Empleados>("dbo.sp_empleados_obtener_por_apellido", param: parametro, commandType: CommandType.StoredProcedure);

                    return empleado;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public Empleados ObtenerEmpleadosPorId(string id)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();

                try
                {
                    var parametro = new DynamicParameters();

                    //"pIdSupplier" corresponde al nombre que tiene el id en nuestro sp de la BD, "id" es el dato que pasaremos en este metodo 
                    parametro.Add("@pIdEmpleado", id);

                    //aqui entra en ejecucion el ORM
                    var empleado = conexion.QuerySingleOrDefault<Empleados>("dbo.sp_empleados_obtener_por_id", param: parametro, commandType: CommandType.StoredProcedure);

                    return empleado;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
