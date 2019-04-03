using System;
using System.Collections.Generic;

namespace FlashCards
{
    public class Flashcard
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
        public string ImageName { get; set; }
    }

    public class RootObject
    {
        public List<Flashcard> Flashcards { get; set; }
    }
}
