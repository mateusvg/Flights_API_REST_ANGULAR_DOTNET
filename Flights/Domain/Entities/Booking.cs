using System.ComponentModel.DataAnnotations; // Data annotation, são atributos que podemos passar para um campo. Ou seja, FlightId e os outros atributos são necessário para que se ache as informações de voo, passageiro e numero de assentos

namespace Flights.Domain.Entities
{
    public record Booking(
         Guid FlightId,
         string PassengerEmail,
         byte NumberOfSeats

        );

}
