using Exceptions.Exceptions;
using Exceptions.Parts;

namespace Exceptions.Entities
{
    public abstract class Vehicle
    {
        public int Id { get; set; }
        public Engine Engine { get; set; }
        public Chassis Chassis { get; set; }
        public Transmission Transmission { get; set; }

        public Vehicle() { }

        public Vehicle(int id)
        {
            if (id <= 0 ) throw new InitializationException("Id cannot be zero or a negative number");
            Id = id;
        }
    }
}
