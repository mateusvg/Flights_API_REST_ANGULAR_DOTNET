using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Flights.Dtos;

namespace Flights.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]


        //IAction results são responsáveis por retornar status code
        //DTOs são objetos que podemos passar como parametros
        //Se chamar-mos o endpoint Register abaixo, nos temos que informar que tipo de informação é o NewPassenger (Verificar o que irá passar no DTO NEWPASSENGERDTO)
        public IActionResult Register(NewPassengerDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
