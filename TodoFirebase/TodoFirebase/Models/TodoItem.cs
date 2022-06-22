﻿using System;
using System.Threading;

namespace TodoFirebase
{
    public class TodoItem
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        public bool Done { get; set; }

        public TodoItem() {}

        public TodoItem(TodoItem todo)
        {
            this.Name = todo.Name;
            this.Priority = todo.Priority;
            this.Done = todo.Done;
        }
    }
}