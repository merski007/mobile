using System;
using System.Collections.Generic;
using SQLite;

namespace FOTD.Models
{
    public class FlavorCalendar
    {
        public FlavorCalendar(){}

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string FlavorId { get; set; }

    }
}

