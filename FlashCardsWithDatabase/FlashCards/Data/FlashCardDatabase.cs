using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlashCards.Model;
using SQLite;

namespace FlashCards.Data
{
    public class FlashCardDatabase
    {

        readonly SQLiteAsyncConnection database;



        public FlashCardDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Flashcard>().Wait();
            List<Flashcard> cards = new List<Flashcard>()
                {
                    new Flashcard("Name the element", "Oxygen","oxygen.png"),
                    new Flashcard("Name the element", "Fluorine","fluorine.png"),
                    new Flashcard("Name the element", "Helium","helium.png")
                };
            //build DB from list
            foreach (Flashcard c in cards)
            {
                SaveItemAsync(c);
            }
        }

        public Task<List<Flashcard>> GetItemsAsync()
        {
            //return database.QueryAsync<Flashcard>("SELECT * FROM [FlashCardItem]");
            return database.Table<Flashcard>().ToListAsync();
        }

        public Task<int> SaveItemAsync(Flashcard card)
        {
            if (card.Id != 0)
            {
                return database.UpdateAsync(card);
            }
            else
            {
                return database.InsertAsync(card);
            }
        }
    }
}
