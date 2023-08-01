namespace Flights.Domain.Entities
{
    public record Flight(
        Guid Id,
        string Airline,
        string Price,
        Timeplace Departure,
        Timeplace Arrival,
        int RemainingNumberOfSeats

        );
}
