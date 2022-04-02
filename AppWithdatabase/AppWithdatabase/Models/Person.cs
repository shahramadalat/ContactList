using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppWithdatabase.Models
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Telephone { get; set; }
        public string Detail { get; set; }
    }
}
