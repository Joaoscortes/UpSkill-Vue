using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace api.Models
{
    public class User: Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
