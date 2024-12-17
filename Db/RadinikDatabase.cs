﻿using RadinikMAUIDemo.Comman;
using RadinikMAUIDemo.Models;
using SQLite;

namespace RadinikMAUIDemo.Db
{
    public class RadinikDatabase
    {
        SQLiteAsyncConnection Database;

        public RadinikDatabase()
        {
        }

        public async Task<List<TodoItem>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<TodoItem>().ToListAsync();
        }

        public async Task<List<TodoItem>> GetItemsNotDoneAsync()
        {
            await Init();
            return await Database.Table<TodoItem>().Where(t => t.Done).ToListAsync();

            // SQL queries are also possible
            //return await Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public async Task<TodoItem> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<TodoItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(TodoItem item)
        {
            await Init();
            if (item.Id != 0)
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(TodoItem item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<TodoItem>();
        }
    }
}
