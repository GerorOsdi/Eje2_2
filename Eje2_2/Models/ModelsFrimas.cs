using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Eje2_2.Models
{
    public class ModelsFrimas
    {
        [PrimaryKey,AutoIncrement]
        public int Id { set; get; }
        public string Name { set; get; }
        public string Descp { set; get; }
        public Byte[] foto { set; get; }
    }
}
