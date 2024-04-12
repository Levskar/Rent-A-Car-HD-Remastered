using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;

namespace Rent_a_car.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int NumberOfPassengerSeats { get; set; }
        public double RentalPrice { get; set; }
        public string Description { get; set; }

        public HashSet<Query> Queries { get; set; }

        public Car() { }
    }
}
