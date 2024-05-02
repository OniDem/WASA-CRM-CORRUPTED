using Core.Const;
using Core.Entity;
using SQLite;
using WASA_Mobile.Const;

namespace WASA_Mobile.Service
{
    public class ApplicationContext
    {
        SQLiteAsyncConnection Database;

        public 

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(SQLiteDBConstants.DatabasePath, SQLiteDBConstants.Flags);
            var result = await Database.CreateTableAsync<AuthUserEntity>();
        }

        public async Task<bool> AddAuthUser(AuthUserEntity authUser)
        {
            await Init();
            if (await Database.InsertAsync(authUser) > 0)
                return true;
            return false;
        }

        public async Task<bool> RemoveAuthUser(AuthUserEntity authUser)
        {
            await Init();
            if (await Database.DeleteAsync(authUser) > 0)
                return true;
            return false;
        }

        public async Task<AuthUserEntity> GetUserInfo()
        {
            await Init();
            var result = await Database.Table<AuthUserEntity>().ToListAsync();
            return result[0];
        }
    }
}
