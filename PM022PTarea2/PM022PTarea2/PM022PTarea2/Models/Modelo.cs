using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM022PTarea2.Models
{
    class Modelo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public String Firma { get; set; } 

    }
}
