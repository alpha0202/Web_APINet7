namespace WebAPI_Udemy.Servicios
{
    public class ServicioEmpleado : IServicioEmpleado
    {
        private readonly List<Empleados> listaEmpleados = new()

           {

               new Empleados {Id=1, Nombre="edwin",CodEmpleado="A001",Email="alpha0202@gmail.com", Edad=38, FechaAlta=DateTime.Now, FechaBaja=null},
               new Empleados {Id=2, Nombre="juan",CodEmpleado="A002",Email="correo2@gmail.com", Edad=40, FechaAlta=DateTime.Now, FechaBaja=null},
               new Empleados {Id=3, Nombre="carlos",CodEmpleado="A010",Email="correo10@gmail.com", Edad=33, FechaAlta=DateTime.Now, FechaBaja = null},
               new Empleados {Id=4, Nombre="oscar",CodEmpleado="A021",Email="correo21@gmail.com", Edad=42, FechaAlta=DateTime.Now, FechaBaja = null}
           };


        public IEnumerable<Empleados> GetEmpleados()
        {
           
            return listaEmpleados;
            
        }

        public Empleados GetEmpleadoByCod(string codEmpleado)
        {
            return listaEmpleados.Where(e => e.CodEmpleado == codEmpleado).SingleOrDefault();
        }


        public void NuevoEmpleado(Empleados emp)
        {
            listaEmpleados.Add(emp);
        }


        public void ModificarEmpleado(Empleados emp)
        {
            int posicion = listaEmpleados.FindIndex(existeEmpleado => existeEmpleado.Id== emp.Id);
            if(posicion != -1)
                listaEmpleados[posicion] = emp;
        }

        public void BajaEmpleado(string codEmpleado)
        {
            int posicion = listaEmpleados.FindIndex(existeEmpleado => existeEmpleado.CodEmpleado== codEmpleado);
            if (posicion != -1)
                listaEmpleados.RemoveAt(posicion);

        }


    }
}
