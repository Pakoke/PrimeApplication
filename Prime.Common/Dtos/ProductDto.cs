using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.Common.Dtos
{
    public class ProductDto
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UnitsOnInventory { get; set; }
        public 
        public DateTime CreatedOn { get; set; }
    }
}
