using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace prilogg.Models
{
  public  class Zapis
    {
        
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
      
    }
}

