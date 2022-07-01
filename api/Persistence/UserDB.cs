using System;
using System.Linq;
using api.Models;

namespace api.Persistence
{
    public class UserDB : EntityDB<User>
    {
        public UserDB()
        {
            dbEntity = db.Users;
        }

        public User Login(Credential user)
        {
            var dbUser = dbEntity.SingleOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if (dbUser == null)
            {
                return null;
            }
            return dbUser;
        }
    }
}
