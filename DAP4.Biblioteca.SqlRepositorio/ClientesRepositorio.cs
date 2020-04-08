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
    public class ClientesRepositorio : IClientesRepositorio
    {
        public Clientes ActualizarCliente(Clientes cliente)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();

                parametros.Add("@pIdCliente", cliente.id_cliente);
                parametros.Add("@pNombreCliente", cliente.cliente_nombre);
                parametros.Add("@pApellidoCliente", cliente.cliente_apellido);
                parametros.Add("@pFechaNacimientoCliente", cliente.cliente_fecha_nac);
                parametros.Add("@pDomicilioCliente", cliente.cliente_domicilio);
                parametros.Add("@pTelefonoCliente", cliente.cliente_telefono);
                parametros.Add("@pEmailCliente", cliente.cliente_email);

                var resultado = conexion.Execute("dbo.sp_clientes_actualizar", param: parametros, commandType: CommandType.StoredProcedure);

                return resultado > 0 ? cliente : new Clientes();
            }
        }

        public bool EliminarCliente(string id_cliente)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();
                parametros.Add("@pIdCliente", id_cliente);

                var resultado = conexion.Execute("dbo.sp_clientes_eliminar", param: parametros, commandType: CommandType.StoredProcedure);

                return resultado > 0;
            }
        }

        public Clientes InsertarCliente(Clientes cliente)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();

                parametros.Add("@pNombreCliente", cliente.cliente_nombre);
                parametros.Add("@pApellidoCliente", cliente.cliente_apellido);
                parametros.Add("@pFechaNacimientoCliente", cliente.cliente_fecha_nac);
                parametros.Add("@pDomicilioCliente", cliente.cliente_domicilio);
                parametros.Add("@pTelefonoCliente", cliente.cliente_telefono);
                parametros.Add("@pEmailCliente", cliente.cliente_email);
                parametros.Add("@pIdCliente", cliente.id_cliente, DbType.Int32, ParameterDirection.Output);

                var resultado = conexion.ExecuteScalar("dbo.sp_clientes_insertar", param: parametros, commandType: CommandType.StoredProcedure);

                var ClienteId = parametros.Get<Int32>("@pIdCliente");

                cliente.id_cliente = ClienteId;

                return cliente;
            }
        }

        public IEnumerable<Clientes> ListarClientes()
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();

                var coleccion = conexion.Query<Clientes>("dbo.sp_clientes_listar", commandType: CommandType.StoredProcedure);

                return coleccion;
            }
        }

        public Clientes ObtenerClientePorApellido(string cliente_apellido)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();

                try
                {
                    var parametro = new DynamicParameters();

                    //"pIdSupplier" corresponde al nombre que tiene el id en nuestro sp de la BD, "id" es el dato que pasaremos en este metodo 
                    parametro.Add("@pApellidoCliente", cliente_apellido);

                    //aqui entra en ejecucion el ORM
                    var cliente = conexion.QueryFirstOrDefault<Clientes>("dbo.sp_clientes_obtener_por_nombre", param: parametro, commandType: CommandType.StoredProcedure);

                    return cliente;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public Clientes ObtenerClientePorId(string id_cliente)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();

                try
                {
                    var parametro = new DynamicParameters();

                    //"pIdSupplier" corresponde al nombre que tiene el id en nuestro sp de la BD, "id" es el dato que pasaremos en este metodo 
                    parametro.Add("@pIdCliente", id_cliente);

                    //aqui entra en ejecucion el ORM
                    var cliente = conexion.QuerySingleOrDefault<Clientes>("dbo.sp_clientes_obtener_por_id", param: parametro, commandType: CommandType.StoredProcedure);

                    return cliente;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
