using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI_Udemy.Servicios
{
    public class ServicioEmpleadoSQL : IServicioEmpleadoSQL
    {

        private string CadenaConexion;

        //Inicializar la conexion a la bd con nuestra clase conexionBaseDatos
        public ServicioEmpleadoSQL(ConexionBaseDatos conex) 
        {
            CadenaConexion = conex.CadenaConexionSQL;
        }


        //Método del tipo sqlconnection 
        private SqlConnection conexion()
        { 
            return new SqlConnection(CadenaConexion);
        }



        public void BajaEmpleado(string codEmpleado)
        {
            throw new NotImplementedException();
        }

        public Empleados GetEmpleadoByCod(string codEmpleado)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Empleados> GetEmpleados()
        {
            throw new NotImplementedException();
        }

        public void ModificarEmpleado(Empleados emp)
        {
            throw new NotImplementedException();
        }

        public void NuevoEmpleado(Empleados emp)
        {

            SqlConnection sqlConexion = conexion();

            try
            {
                sqlConexion.Open();
                var param = new DynamicParameters();
                param.Add("@Nombre",emp.Nombre,DbType.String, ParameterDirection.Input, 500);
                param.Add("@CodEmpleado", emp.CodEmpleado,DbType.String, ParameterDirection.Input, 4);
                param.Add("@Email", emp.Email,DbType.String, ParameterDirection.Input, 300);
                param.Add("@Edad", emp.Edad,DbType.Int32, ParameterDirection.Input);
                param.Add("@FechaAlta", emp.FechaAlta,DbType.DateTime, ParameterDirection.Input);
                sqlConexion.ExecuteScalar("EmpleadoAlta", param, commandType: CommandType.StoredProcedure);


            }
            catch (Exception ex)
            {

                throw new Exception("Se produjo un error al dar de alta" + ex.Message);
            }
            finally 
            { 
                sqlConexion.Close();
                sqlConexion.Dispose();
            }
        }
    }
}
