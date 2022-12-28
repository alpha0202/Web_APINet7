namespace WebAPI_Udemy.Servicios
{
    public interface IServicioEmpleado
    {

        public IEnumerable<Empleados> GetEmpleados();


        public Empleados GetEmpleadoByCod(string codEmpleado);



        public void NuevoEmpleado(Empleados emp);

    }
}
