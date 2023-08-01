using System.Data;

namespace Flights.Domain.Entities
{
    public record Timeplace(string Place, DataSetDateTime Time);// não pe necessário criar get, set

}
