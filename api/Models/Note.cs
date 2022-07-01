using System;
using System.Text.Json.Serialization;

namespace api.Models
{
    public class Note : Entity
    {

        public string Message { get; set; }
        public int AuthorId { get; set; }
    }
}
