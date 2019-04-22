using System;
using System.Collections.Generic;

namespace ListViewProject
{

        public class FlashCard
        {
            public string Question { get; set; }
            public string Answer { get; set; }
            public bool IsCorrect { get; set; }
            public string ImageName { get; set; }
        }

        public class RootObject
        {
            public List<FlashCard> FlashCards { get; set; }
        }

}
