using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace prilogg.Models
{
   public class Ystroistva
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username1 { get; set; }
        public string Password1 { get; set; }
        public string ip { get; set; }
        public string port { get; set; }
    }
}
