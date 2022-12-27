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
    }
}
