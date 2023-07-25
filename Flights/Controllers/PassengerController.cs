using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Flights.Dtos;
using Flights.ReadModels;

namespace Flights.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        static private IList<NewPassengerDto> _passengerList = new List<NewPassengerDto>();

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        //IAction results são responsáveis por retornar status code
        //DTOs são objetos que podemos passar como parametros
        //Se chamar-mos o endpoint Register abaixo, nos temos que informar que tipo de informação é o NewPassenger (Verificar o que irá passar no DTO NEWPASSENGERDTO)
        public IActionResult Register(NewPassengerDto dto)
        {
            _passengerList.Add(dto);
            System.Diagnostics.Debug.WriteLine(_passengerList.Count);
            return Ok();
            //throw new NotImplementedException();
        }

        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IEnumerable<NewPassengerDto> Search()
            => _passengerList.ToList();

    }
}
