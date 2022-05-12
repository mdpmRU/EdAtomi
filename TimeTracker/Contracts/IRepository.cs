using DataContracts.Entities;

namespace Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        public IEnumerable<T>? GetAll();

        public void Insert(T obj);
    }
}