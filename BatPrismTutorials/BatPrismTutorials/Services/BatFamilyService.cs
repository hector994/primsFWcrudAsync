using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BatPrismTutorials.Model;
using SQLite;

namespace BatPrismTutorials.Services
{
    public class BatFamilyService : IBatFamilyService
    {
        private ISQLiteConnectionProvider LiteconectionProvider { get; }
        private SQLiteAsyncConnection LiteConnection { get; }

        public BatFamilyService(ISQLiteConnectionProvider liteconectionProvider)
        {
            this.LiteconectionProvider = liteconectionProvider;
            this.LiteConnection = this.LiteconectionProvider.GetConnection();
            this.LiteConnection.CreateTableAsync<BatFamily>();
        }

        /// <summary>
        /// //////////
        /// </summary>
        /// <param name="id"></param>
        //public void Delete(int id)
        //{
        //    this.LiteConnection.Delete<BatFamily>(id);
        //}

        //public IEnumerable<BatFamily> GetFamilies()
        //{
        //    return this.LiteConnection.Table<BatFamily>().ToList();
        //}

        //public void Insert(BatFamily BatParent)
        //{
        //    this.LiteConnection.Insert(BatParent);
        //}

        //public void Update(BatFamily BatParent)
        //{
        //    this.LiteConnection.Update(BatParent);
        //}

        //public BatFamily GetById(int id)
        //{
        //    return this.LiteConnection.Table<BatFamily>().FirstOrDefault(x => x.Id == id);
        //}
        /// <summary>
        /// /////////////////
        /// </summary>
        /// <returns></returns>
        /// 


        public async Task DaleteAsync(BatFamily todoItem)
        {
            await this.LiteConnection.CreateTableAsync<BatFamily>();
            await this.LiteConnection.DeleteAsync(todoItem);
        }
        public async Task<IEnumerable<BatFamily>> GetAllAsync()
        {
            await this.LiteConnection.CreateTableAsync<BatFamily>();
            return await this.LiteConnection.Table<BatFamily>().ToListAsync(); 
        }

        public async Task<BatFamily> GetByIdAsync(int id)
        {
            await this.LiteConnection.CreateTableAsync<BatFamily>();
            return await this.LiteConnection.Table<BatFamily>().Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(BatFamily todoItem)
        {
            await this.LiteConnection.CreateTableAsync<BatFamily>();
            await this.LiteConnection.UpdateAsync(todoItem);
        }

        public async Task InsertAsync(BatFamily todoItem)
        {
            await this.LiteConnection.CreateTableAsync<BatFamily>();
            await this.LiteConnection.InsertAsync(todoItem);
        }


    }
}
