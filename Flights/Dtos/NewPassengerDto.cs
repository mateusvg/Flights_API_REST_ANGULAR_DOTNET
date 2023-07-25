namespace Flights.Dtos
{
    public record NewPassengerDto(
        string Email,
        string FisrtName,
        string LastName,
        bool Gender
        );
}
