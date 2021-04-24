using JoseQuizApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace JoseQuizApp.Repositories
{
    public class AnswerRepository : IRepository<AnswerModel>
    {
        private SQLiteAsyncConnection _connection;
        public async Task Connect(string connectionString = "")
        {
            if (_connection != null)
            {
                return;
            }

            var projPath = /*@"D:\GitHubRepo\JoseQuizApp\JoseQuizApp\JoseQuizApp\Db\"*/Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dataBasePath = Path.Combine(projPath, "QuizDb.db");

            _connection = new SQLiteAsyncConnection(dataBasePath);
            await _connection.CreateTableAsync<AnswerModel>();
        }
        public async Task AddItem(AnswerModel item)
        {
            await Connect();
            await _connection.InsertAsync(item);

        }

        public async Task AddOrUpdateItem(AnswerModel item)
        {
            if (item.Id == 0)
            {
                await AddItem(item);
            }
            else
            {
                await UpdateItem(item);
            }
        }



        public async Task DeleteItem(AnswerModel item)
        {
            await Connect();
            await _connection.DeleteAsync(item);
        }

        public async Task<List<AnswerModel>> GetItems()
        {
            await Connect();
            return await _connection.Table<AnswerModel>().ToListAsync();
        }

        public async Task<AnswerModel> GetItem_ByItem(int id)
        {
            await Connect();
            return await _connection.FindAsync<AnswerModel>(id);
        }

        public async Task UpdateItem(AnswerModel item)
        {
            await Connect();
            await _connection.UpdateAsync(item);
        }
    }
}
