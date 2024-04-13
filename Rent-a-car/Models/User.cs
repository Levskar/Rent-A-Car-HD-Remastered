using Microsoft.AspNetCore.Identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;

namespace Rent_a_car.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string UID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public HashSet<Query> Queries { get; set; }
        public User() { }
    }
}
