using System;
using api.Models;
using api.Persistence;

namespace api.Business
{
    public class NoteBusiness : EntityBusiness<Note, NoteDB>
    {
        public NoteBusiness()
        {
            database = new NoteDB();
        }
    }
}
