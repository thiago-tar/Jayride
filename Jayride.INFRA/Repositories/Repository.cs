using Jayride.Domain.Entities;
using Jayride.Domain.Interfaces.Repositories;
using System.Security.Cryptography.X509Certificates;

namespace Jayride.Infra.Repositories
{
    public abstract class Repository<Entity> : IRepository<Entity> where Entity : BaseEntity
    {
        private List<Entity> _entities;
        protected Repository()
        {
            _entities = new List<Entity>();
        }

        public virtual Entity Add(Entity entity)
        {
            var lastId = GetAll().Select(x => x.Id)?.OrderByDescending(x => x)?.FirstOrDefault()??0;

            entity.Id = lastId + 1;
            _entities.Add(entity);

            return entity;
        }

        public virtual void Delete(int id) => _entities.Remove(Get(id));


        public virtual Entity Get(int id) => _entities.FirstOrDefault(x => x.Id == id);



        public virtual IEnumerable<Entity> GetAll() => _entities;

    }
}
