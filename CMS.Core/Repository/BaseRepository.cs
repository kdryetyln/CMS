using CMS.Core.Context;
using CMS.Domain.Models;
using CMS.Domain.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Repository
{
    public class BaseRepository<T> : IDisposable where T : class, IBaseEntity
    {
        CMSDbContext _db = null;
        public DbSet<T> Entity { get { return _db.Set<T>(); } }

        public BaseRepository()
        {
            _db = new CMSDbContext();
        }

        public virtual bool Add(T entity)
        {
            entity.CreateTime = DateTime.Now;
            Entity.Add(entity);
            return _db.SaveChanges() > 0;
        }

        public virtual T Find(int id)
        {
            return Entity.FirstOrDefault(k => k.Id == id);
        }

        public virtual bool Delete(T entity)
        {            
            if(entity!=null&&entity.Id!=default(int))
            {
                var record = Find(entity.Id);
                if(record==null)
                {
                    throw new NullReferenceException(nameof(entity.Id));
                }
                record.IsDeleted = true;
                return _db.SaveChanges()>0;
            }
            throw new ArgumentOutOfRangeException(nameof(entity.Id));
        }

        public virtual bool DeletePage(T entity)
        {
            Entity.Remove(entity);
            return _db.SaveChanges() > 0;
        }

        public virtual bool Update(T entity)
        {
            entity.IsDeleted = false;
            _db.Set<T>().AddOrUpdate(entity);
            _db.SaveChanges();
            return _db.SaveChanges() > 0;
        }

        public IQueryable<IBaseEntity> ListAll()
        {
            return Entity;
        }

        public IQueryable<E> Query<E>() where E:class
        {
            return _db.Set<E>();
        }



        public void Dispose()
        {
            if(_db!=null)
            {
                _db.Dispose();
            }
        }
    }
}
