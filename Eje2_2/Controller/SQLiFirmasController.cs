using System;
using System.Collections.Generic;
using System.Text;
using Eje2_2.Models;
using System.Threading.Tasks;
using SQLite;

namespace Eje2_2.Controller
{
    public class SQLiFirmasController
    {
        readonly SQLiteAsyncConnection connection;

        public SQLiFirmasController(string path)
        {
            connection = new SQLiteAsyncConnection(path);
            connection.CreateTableAsync<ModelsFrimas>();
        }

        public Task<int> SaveFirma(ModelsFrimas firma)
        {
            if(firma.Id != 0)
            {
                return connection.UpdateAsync(firma);
            }
            else
            {
                return connection.InsertAsync(firma);
            }
        }

        public Task<List<ModelsFrimas>> GetFirmas()
        {
            return connection.Table<ModelsFrimas>().ToListAsync();
        }

    }
}
