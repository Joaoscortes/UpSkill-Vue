using System;
using api.Business;
using api.Models;
using api.Persistence;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NoteController : EntityController<Note, NoteDB, NoteBusiness>
    {
        public NoteController(ILogger<NoteController> logger) : base(logger)
        {
            business = new NoteBusiness();
        }
    }
}
