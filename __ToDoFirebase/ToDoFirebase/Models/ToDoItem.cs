using System;

namespace ToDoFirebase.Models
{
    public class ToDoItem
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public int Priority { get; set; }
        public bool Done { get; set; }
    }
}
