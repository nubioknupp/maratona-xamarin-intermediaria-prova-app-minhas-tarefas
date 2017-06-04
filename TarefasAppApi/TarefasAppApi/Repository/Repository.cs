using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TarefasApp.REST.ClienteAPI.Context;
using TarefasApp.REST.ClienteAPI.Repository.Interfaces;

namespace TarefasApp.REST.ClienteAPI.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected TarefaContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository()
        {
            Db = new TarefaContext();
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            var objReturn = DbSet.Add(obj);
            SaveChanges();
            return objReturn;
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()//(int s, int t)
        {
            return DbSet.ToList(); //Take(t).Skip(s).ToList();
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            SaveChanges();

            return obj;
        }

        public virtual void Remover(Guid id)
        {
            DbSet.Remove(ObterPorId(id));
            SaveChanges();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}