using System;
using api.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace api.Persistence
{
    public abstract class EntityDB<T> where T : Entity
    {
        protected SqliteDB db = new SqliteDB();
        protected DbSet<T> dbEntity;

        public async Task<List<T>> GetAll()
        {
            return await Task.Run(() => dbEntity.ToList());
        }

        public virtual async Task<T> GetById(int id)
        {
            return await Task.Run(() => dbEntity.Find(id));
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                entity.Updated = DateTime.Now;
                await Task.Run(() => db.Update(entity));
                db.SaveChanges();
                Console.WriteLine(entity);
                return entity;
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e);
                return null;
            }
        }

        public async Task<T> Add(T entity)
        {
            try
            {
                entity.Created = DateTime.Now;
                entity.Updated = DateTime.Now;
                await Task.Run(() => db.Add(entity));
                db.SaveChanges();
                Console.WriteLine(entity);
                return entity;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public async Task<bool> Remove(int entityId)
        {

            T entity = await Task.Run(() => GetById(entityId));

            if (entity != null)
            {
                db.Remove(entity);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
