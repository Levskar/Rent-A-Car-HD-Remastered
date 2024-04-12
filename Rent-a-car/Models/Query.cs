using System;

namespace Rent_a_car.Models
{
    public class Query
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car CarToRent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public User RentingUser { get; set; }
        public Query() { }
    }
}
