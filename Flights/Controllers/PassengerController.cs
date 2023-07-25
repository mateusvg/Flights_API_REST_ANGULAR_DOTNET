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
            return CreatedAtAction(nameof(Find), new { email = dto.Email }); // utiliza o metodo find abaixo para retornar uma URI com o e-mail criado ex: https:/Passenger?email=john%40teste.com
            //return Ok();
            //throw new NotImplementedException();
        }

        //ActionResult<retorna Passenger Read Model> nomeamos de Find (para encontrar pelo e-mail)
        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<PassengerRm> Find(string email)
        {
            var passenger = _passengerList.SingleOrDefault(f => f.Email == email);
            if (email == null)
            {
                return NotFound();
            }
            //temos que criar um novo Read Model, pois o _passengerList retorna o DTO
            var rm = new PassengerRm(
                    passenger.Email,
                    passenger.FirstName,
                    passenger.LastName,
                    passenger.Gender
                );
            return Ok(rm); // caso encontro o email na lista retorna no response body

        }


        ////Lista todos os passageiros

        //[HttpGet("passengersTest")]
        //[ProducesResponseType(201)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(500)]
        //public IEnumerable<NewPassengerDto> Search()
        //    => _passengerList.ToList();

    }
}
