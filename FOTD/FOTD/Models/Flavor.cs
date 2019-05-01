using System;
using System.Collections.Generic;
using SQLite;

namespace FOTD.Models
{
    public class Flavor
    {
        public Flavor() { }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FlavorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }

        public Flavor(string flavorId,string name, string description, string company)
        {
            this.FlavorId = flavorId;
            this.Name = name;
            this.Description = description;
            this.Company = company;
        }

    }
}
