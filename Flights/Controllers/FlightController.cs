using Flights.Dtos;
using Flights.ReadModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Flights.Controllers
{
    [ApiController] //realiza validações nos DTOs
    [Route("[controller]")]

    //[ProducesResponseType(400)] pode ser removido dos metodos abaixo e para que todos os status code seja disponivel para todos os metodos da API basta listalos aqui no controller
    //[ProducesResponseType(500)]

    public class FlightController : ControllerBase
    {
        private readonly ILogger<FlightController> _logger;


        static Random random = new();

        static private IList<BookDto> Booking = new List<BookDto>();

        static private FlightRm[] flights = new FlightRm[]

            {
        new (   Guid.NewGuid(),
                "Latam",
                random.Next(90, 5000).ToString(),
                new TimePlaceRm("Belo Horizonte", System.Data.DataSetDateTime.Local),
                new TimePlaceRm("Rio de Janeiro",System.Data.DataSetDateTime.Local),
                    random.Next(1, 853)),
        new (   Guid.NewGuid(),
                "Deutsche BA",
                random.Next(90, 5000).ToString(),
                new TimePlaceRm("Munchen",System.Data.DataSetDateTime.Local),
                new TimePlaceRm("Schiphol",System.Data.DataSetDateTime.Local),
                random.Next(1, 853)),
        new (   Guid.NewGuid(),
                "British Airways",
                random.Next(90, 5000).ToString(),
                new TimePlaceRm("Rio, Brazil",System.Data.DataSetDateTime.Local),
                new TimePlaceRm("Vizzola-Ticino",System.Data.DataSetDateTime.Local),
                    random.Next(1, 853)),

            };


        public FlightController(ILogger<FlightController> logger)
        {
            _logger = logger;
        }



        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(IEnumerable<FlightRm>), 200)]
        [HttpGet]
        public IEnumerable<FlightRm> Search()
            => flights;



        //[ProducesResponseType(404)] //pode ser utilizado como inteiro
        [ProducesResponseType(StatusCodes.Status404NotFound)] //na documentação produz um resultado diferente do não documentado
        [ProducesResponseType(400)] //o cliente enviou uma requisição invalida. Os status code agora ficam listados na documentação da API
        [ProducesResponseType(500)] // o servidor recebeu a requisição porém, não foi possível de processa-la Ex: devido a uma falha na conexão com o banco
        [ProducesResponseType(typeof(FlightRm), 200)] // para habilitar na documentação responses do tipo 200
        [HttpGet("{id}")]
        public ActionResult<FlightRm> Find(Guid id)// action result é uma maneira de retornar status code como: 500 ou 200
        {
            var flight = flights.SingleOrDefault(f => f.Id == id);
            if (flight == null)
            {
                return NotFound();
            }
            return Ok(flight); // assim o metodo Ok resulta na criação de um status 200

        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(200)]
        public IActionResult Book(BookDto dto)
        {
            System.Diagnostics.Debug.WriteLine($"Booking a new flight {dto.FlightId}");
            var flightFound = flights.Any(f => f.Id == dto.FlightId);

            if (flightFound == false)
                return NotFound();

            Booking.Add(dto);
            return CreatedAtAction(nameof(Find), new { id = dto.FlightId }); // no reponse podemos achar o URI do flightID
        }

    }
}