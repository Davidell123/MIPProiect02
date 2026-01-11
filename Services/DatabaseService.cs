using SQLite;
using MIPProiect02.Models;

namespace MIPProiect02.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database = default!;

        private async Task Init()
        {
            if (_database is not null) return;
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "MIPTodo.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            await _database.CreateTableAsync<TodoItem>();
        }

        public async Task<List<TodoItem>> GetItemsAsync()
        {
            await Init();
            return await _database.Table<TodoItem>().ToListAsync();
        }

        public async Task<int> SaveItemAsync(TodoItem item)
        {
            await Init();
            return item.Id != 0 ? await _database.UpdateAsync(item) : await _database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(TodoItem item)
        {
            await Init();
            return await _database.DeleteAsync(item);
        }
    }
}