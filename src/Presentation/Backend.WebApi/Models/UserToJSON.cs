using System.Collections;

namespace Backend.WebApi.Models
{
    public class UserToJSON
    {
        public required string Name { get; set; }

        public required string Gender { get; set; }

        public required string IdNumber { get; set; }

        public required string Region { get; set; }

        public required string Area { get; set; }

    }
}
