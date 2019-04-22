using System;
using System.Collections.Generic;
using SQLite;

namespace FlashCards.Model
{
    public class Flashcard
    {
        public Flashcard() { }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
        public string ImageName { get; set; }


        public Flashcard( string a, string b, string d)
        {
            this.Question = a;
            this.Answer = b;
            this.IsCorrect = false;
            this.ImageName = d;
        }
    }

}
