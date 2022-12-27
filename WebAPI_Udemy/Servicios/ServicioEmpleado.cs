namespace WebAPI_Udemy.Servicios
{
    public class ServicioEmpleado : IServicioEmpleado
    {
        private readonly List<Empleados> listaEmpleados = new()

           {

               new Empleados {Id=1, Nombre="edwin",CodEmpleado="A001",Email="alpha0202@gmail.com", Edad=38, FechaAlta=DateTime.Now},
               new Empleados {Id=2, Nombre="juan",CodEmpleado="A002",Email="correo2@gmail.com", Edad=40, FechaAlta=DateTime.Now},
               new Empleados {Id=3, Nombre="carlos",CodEmpleado="A010",Email="correo10@gmail.com", Edad=33, FechaAlta=DateTime.Now},
               new Empleados {Id=4, Nombre="oscar",CodEmpleado="A021",Email="correo21@gmail.com", Edad=42, FechaAlta=DateTime.Now}
           };


        public IEnumerable<Empleados> GetEmpleados()
        {
           
            return listaEmpleados;
            
        }
    }
}
