using WebAPI_Udemy.DTO;

namespace WebAPI_Udemy
{
    public static class Utilidades
    {
        public static EmpleadoDTO ConvertirDTO(this Empleados e)
        {
            if (e != null)
            {
                return new EmpleadoDTO

                {
                    Nombre = e.Nombre,
                    CodEmpleado = e.CodEmpleado,
                    Email = e.Email,
                    Edad = e.Edad
                };
            }

            return null;
        }

    }
}
