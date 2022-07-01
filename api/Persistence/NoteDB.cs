using System;
using System.Linq;
using api.Models;

namespace api.Persistence
{
    public class NoteDB : EntityDB<Note>
    {
        public NoteDB()
        {
            dbEntity = db.Notes;
        }
    }
}
