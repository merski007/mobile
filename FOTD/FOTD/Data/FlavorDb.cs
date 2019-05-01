using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FOTD.Models;
using SQLite;
using System.Linq;

namespace FOTD.Data
{
    public class FlavorDb
    {
        readonly SQLiteAsyncConnection _database;

        public FlavorDb(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            //+_database.CreateTableAsync<Flavor>().Wait();
            _database.CreateTableAsync<Flavor>();

            List<Flavor> flavors = new List<Flavor>()
            {
                new Flavor("K001","Mint Chip","Mint Custard + Chocolate Chips", "Kopps"),
                new Flavor("K002","Wedding Cake","Cake Batter Custard + Frosting + Sponge Cake +\nRaspberry + Bavarian Cream", "Kopps"),
                new Flavor("K003","Hey Cupcake","Vanilla Custard + Sponge Cake + Fudge +\nMini Rainbow Chips","Kopps"),
                new Flavor("K004","Tiramisu","Espresso Custard + Fudge + Tiramisu","Kopps"),
                new Flavor("O001","Funkee... Monkey","", "Oscars"),
                new Flavor("O002","Drumstik","", "Oscars"),
                new Flavor("O003","Strawberry Shortcake","", "Oscars"),
                new Flavor("O004","Butter Brickle","", "Oscars")
            };

            foreach(Flavor f in flavors)
            {
                SaveItemAsync(f);
            }
        }

        public Task<List<Flavor>> GetItemsAsync()
        {
            //return database.QueryAsync<Flashcard>("SELECT * FROM [FlashCardItem]");
            //var x = _database.Table<Flavor>().ToArrayAsync();

            return _database.Table<Flavor>().ToListAsync();
        }

        public Task<int> SaveItemAsync(Flavor flavor)
        {
            //var exists = _database.Table<Flavor>().Where(f => f.FlavorId == flavor.FlavorId);

            if (flavor.Id != 0)
            {
                return _database.UpdateAsync(flavor);
            }
            else
            {
                return _database.InsertAsync(flavor);
            }
        }
    }
}
