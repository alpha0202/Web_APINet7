using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Udemy.DTO;
using WebAPI_Udemy.Servicios;

namespace WebAPI_Udemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {

        private readonly IServicioEmpleado _servicioEmpleado;


        public EmpleadoController(IServicioEmpleado servicioEmpleado)
        {
            _servicioEmpleado = servicioEmpleado;
        }






        [HttpGet]
        public IEnumerable<EmpleadoDTO> GetEmpleados()
        {
            var listaEmpleados =  _servicioEmpleado.GetEmpleados().Select(e => e.ConvertirDTO());

            return listaEmpleados;
        }



        [HttpGet("{codEmpleado}")]

        public ActionResult<EmpleadoDTO> GetEmpleadoByCod(string codEmpleado)
        {
            var empleado = _servicioEmpleado.GetEmpleadoByCod(codEmpleado).ConvertirDTO();
            if(empleado is null)
            {
                return NotFound();
            }
            return empleado;
        }

        [HttpPost]
        public ActionResult<EmpleadoDTO> NuevoEmpleado(EmpleadoDTO empDTO)
        {
            Empleados empleados = new Empleados
            {
                Id = _servicioEmpleado.GetEmpleados().Max(e => e.Id) + 1,
                CodEmpleado = empDTO.CodEmpleado,
                Nombre = empDTO.Nombre,
                Email = empDTO.Email,
                Edad = empDTO.Edad,
                FechaAlta = DateTime.Now,

            };

            _servicioEmpleado.NuevoEmpleado(empleados);
            return empleados.ConvertirDTO();
        }

        [HttpPut]
        public ActionResult<EmpleadoDTO> ModificarEmpleado(EmpleadoDTO emp)
        {
            var empleadoAux = _servicioEmpleado.GetEmpleadoByCod(emp.CodEmpleado);
            if (empleadoAux is null)
            {
                return NotFound();
            }

            empleadoAux.CodEmpleado= emp.CodEmpleado;
            empleadoAux.Nombre= emp.Nombre; 
            empleadoAux.Email= emp.Email;   
            empleadoAux.Edad= emp.Edad;

            _servicioEmpleado.ModificarEmpleado(empleadoAux);

            return emp;
        }

        [HttpDelete]

        public ActionResult BorrarEmpleado(string codEmpleado)
        {
            var empleadoBorrar = _servicioEmpleado.GetEmpleadoByCod(codEmpleado);
            if (empleadoBorrar is null)
            {
                return NotFound();
            }

            _servicioEmpleado.BajaEmpleado(codEmpleado);
            return Ok();
        }


    }
}
