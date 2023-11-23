using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Services.Repositories.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Implementations
{
    /// <summary>
    /// Репозиторий чтения и записи
    /// </summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    /// <typeparam name="TPrimaryKey">Основной ключ</typeparam>
    public abstract class Repository<T, TPrimaryKey> : ReadRepository<T, TPrimaryKey>, IRepository<T, TPrimaryKey> where T 
        : class, IEntity<TPrimaryKey>
    {
        protected Repository(DbContext context): base(context)
        {
        }

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="id">ID удалённой сущности</param>
        /// <returns>была ли сущность удалена</returns>
        public virtual bool Delete(TPrimaryKey id)
        {
            var obj = EntitySet.Find(id);
            if (obj == null)
            {
                return false;
            }
            EntitySet.Remove(obj);
            return true;
        }

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="entity">сущность для удаления</param>
        /// <returns>была ли сущность удалена</returns>
        public virtual bool Delete(T entity)
        {
            if (entity == null)
            {
                return false;
            }
            Context.Entry(entity).State = EntityState.Deleted;
            return true;
        }

        /// <summary>
        /// Удалить сущности
        /// </summary>
        /// <param name="entities">Коллекция сущностей для удаления</param>
        /// <returns>была ли операция завершена успешно</returns>
        public virtual bool DeleteRange(ICollection<T> entities)
        {
            if (entities == null || !entities.Any())
            {
                return false;
            }
            EntitySet.RemoveRange(entities);
            return true;
        }

        /// <summary>
        /// Для сущности проставить состояние - что она изменена
        /// </summary>
        /// <param name="entity">сущность для изменения</param>
        public virtual void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Добавить в базу одну сущность
        /// </summary>
        /// <param name="entity">сущность для добавления</param>
        /// <returns>добавленная сущность</returns>
        public virtual T Add(T entity)
        {
            var objToReturn = Context.Set<T>().Add(entity);
            return objToReturn.Entity;
        }

        /// <summary>
        /// Добавить в базу одну сущность
        /// </summary>
        /// <param name="entity">сущность для добавления</param>
        /// <returns>добавленная сущность</returns>
        public virtual async Task<T> AddAsync(T entity)
        {
            return (await Context.Set<T>().AddAsync(entity)).Entity;
        }

        /// <summary>
        /// Добавить в базу массив сущностей
        /// </summary>
        /// <param name="entities">массив сущностей</param>
        public virtual void AddRange(List<T> entities)
        {
            var enumerable = entities as IList<T> ?? entities.ToList();
            Context.Set<T>().AddRange(enumerable);
        }

        /// <summary>
        /// Добавить в базу массив сущностей
        /// </summary>
        /// <param name="entities">массив сущностей</param>
        public virtual async Task AddRangeAsync(ICollection<T> entities)
        {
            if (entities == null || !entities.Any())
            {
                return;
            }
            await EntitySet.AddRangeAsync(entities);
        }

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        public virtual void SaveChanges()
        {
            Context.SaveChanges();
        }

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await Context.SaveChangesAsync(cancellationToken);
        }
    }
}
