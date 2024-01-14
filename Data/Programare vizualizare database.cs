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
            _database.CreateTableAsync<Tablou>().Wait();
            _database.CreateTableAsync<Listă_tablouri>().Wait();
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

        public Task<int> SaveTablouAsync(Tablou tablou)
        {
            if (tablou.ID != 0)
            {
                return _database.UpdateAsync(tablou);
            }
            else
            {
                return _database.InsertAsync(tablou);
            }
        }
        public Task<int> DeleteTablouAsync(Tablou tablou)
        {
            return _database.DeleteAsync(tablou);
        }
        public Task<List<Tablou>> GetTablouAsync()
        {
            return _database.Table<Tablou>().ToListAsync();
        }

        public Task<int> SaveListă_tablouriAsync(Listă_tablouri listt)
        {
            if (listt.ID != 0)
            {
                return _database.UpdateAsync(listt);
            }
            else
            {
                return _database.InsertAsync(listt);
            }
        }
        public Task<List<Tablou>> GetListă_tablouriAsync(int programare_vizualizareid)
        {
            return _database.QueryAsync<Tablou>(
            "select T.ID, T.Description from Tablou T"
            + " inner join Listă_Tablouri LT"
            + " on T.ID = LT.TablouID where LT.Programare_vizualizareID = ?",
            programare_vizualizareid);
        }
    }
}

