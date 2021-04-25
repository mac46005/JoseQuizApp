using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoseQuizApp.Repositories
{
    public interface IRepository<T>
    {
        Task Connect(string connectionString);

        Task<List<T>> GetItems();
        Task AddItem(T item);
        Task UpdateItem(T item);
        Task AddOrUpdateItem(T item);
        Task DeleteItem(T item);
        Task<T> GetItem_ById(int id);
    }
}
