using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Galerie_Arta_Partea2.Models;

namespace Galerie_Arta_Partea2.Data
{
    public class Programare_vizualizare_database
    {
        readonly SQLiteAsyncConnection _database;
        public Programare_vizualizare_database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Programare_vizualizare>().Wait();
        }
        public Task<List<Programare_vizualizare>> GetProgramare_vizualizareAsync()
        {
            return _database.Table<Programare_vizualizare>().ToListAsync();
        }
        public Task<Programare_vizualizare> GetProgramare_vizualizareAsync(int id)
        {
            return _database.Table<Programare_vizualizare>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveProgramare_vizualizareAsync(Programare_vizualizare pvizualizare)
        {
            if (pvizualizare.ID != 0)
            {
                return _database.UpdateAsync(pvizualizare);
            }
            else
            {
                return _database.InsertAsync(pvizualizare);
            }
        }
        public Task<int> DeleteProgramare_vizualizareAsync(Programare_vizualizare pvizualizare)
        {
            return _database.DeleteAsync(pvizualizare);
        }
    }
}
