using System;
using api.Models;
using api.Persistence;

namespace api.Business
{
    public class UserBusiness: EntityBusiness<User,UserDB>
    {
        public UserBusiness()
        {
            database = new UserDB();
        }

        public User Login(Credential user)
		{
			return database.Login(user);
		}
    }
}
