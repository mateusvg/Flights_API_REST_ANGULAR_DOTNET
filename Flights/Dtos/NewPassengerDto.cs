using System.ComponentModel.DataAnnotations;

namespace Flights.Dtos
{
    public record NewPassengerDto(
       [Required][EmailAddress][StringLength(100, MinimumLength = 10)] string Email,
       [Required][MinLength(2)][MaxLength(50)] string FirstName,
       [Required][MinLength(2)][MaxLength(50)] string LastName,
       [Required] bool Gender
        );
}
