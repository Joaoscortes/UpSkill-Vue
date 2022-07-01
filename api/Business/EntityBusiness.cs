using System;
using api.Models;
using api.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Business
{
    public abstract class EntityBusiness<T, U> where T : Entity where U : EntityDB<T>
    {
        protected U database;

        public async Task<List<T>> GetAll()
        {
            return await database.GetAll();
        }
        public async Task<T> GetById(int id)
        {
            return await database.GetById(id);
        }

        public async Task<T> Update(T entity)
        {
            return await database.Update(entity);
        }

        public async Task<T> Add(T entity)
        {
            return await database.Add(entity);

        }

        public async Task<bool> Remove(int entityId)
        {
            return await database.Remove(entityId);
        }
    }
}
