using JoseQuizApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace JoseQuizApp.Repositories
{
    public class QuestionRepository : IRepository<QuestionModel>
    {
        private SQLiteAsyncConnection _connection;
        public async Task Connect(string connectionstring = "")
        {
            if (_connection != null)
            {
                return;
            }


            var projDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var dataBasePath = Path.Combine(projDirectory, "QuizAppDb.db");

            _connection = new SQLiteAsyncConnection(dataBasePath);
            await _connection.CreateTableAsync<QuestionModel>();
        }
        public async Task AddItem(QuestionModel item)
        {
            await Connect();
            await _connection.InsertAsync(item);
        }

        public async Task AddOrUpdateItem(QuestionModel item)
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

        public async Task DeleteItem(QuestionModel item)
        {
            await Connect();
            await _connection.DeleteAsync(item);
        }

        public async Task<List<QuestionModel>> GetItems()
        {
            await Connect();
            return await _connection.Table<QuestionModel>().ToListAsync();
        }

        public async Task<QuestionModel> GetItem_ById(int id)
        {
            await Connect();
            return await _connection.FindAsync<QuestionModel>(id);
        }

        public async Task UpdateItem(QuestionModel item)
        {
            await Connect();
            await _connection.UpdateAsync(item);
        }
    }
}
