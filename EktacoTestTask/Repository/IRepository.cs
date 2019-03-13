using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EktacoTestTask.Repository
{
    public interface IRepository<T>
        : IDisposable where T : class
    {
        IEnumerable<T> All();
        Task<IEnumerable<T>> AllAsync();
        T Get(int id);
        Task<T> GetAsync(int id);
        void Add(T entity);
    }
}
