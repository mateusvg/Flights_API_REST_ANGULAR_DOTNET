using System.ComponentModel.DataAnnotations; // Data annotation, são atributos que podemos passar para um campo. Ou seja, FlightId e os outros atributos são necessário para que se ache as informações de voo, passageiro e numero de assentos

namespace Flights.Dtos
{
    public record BookDto(
        [Required] Guid FlightId,
        [Required][EmailAddress][StringLength(100, MinimumLength = 10)] string PassengerEmail,
        [Required][Range(1, 254)] byte NumberOfSeats

        );

}
