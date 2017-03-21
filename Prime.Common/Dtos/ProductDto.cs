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
        public ProductDto() { }
        
        /// <summary>
        /// Id of the product
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        
        /// <summary>
        /// Name given to the product
        /// </summary>
        [NotNull]
        public string Name { get; set; }
        
        /// <summary>
        /// The description of the product 
        /// </summary>
        public string Description { get; set; }

        ///// <summary>
        ///// The amount of the product in the storage
        ///// </summary>
        //public int UnitsOnInventory { get; set; }

        /// <summary>
        /// Path of the image
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// The number of prime material that compose the product
        /// </summary>
        public List<PrimeMaterialDto> ComposeOfTheProduct { get; set; }

        /// <summary>
        /// Shop which the product belong 
        /// </summary>
        [NotNull]
        public ShopDto ShopWhichBelongTo { get; set; }

        /// <summary>
        /// The date when the product is created in the system
        /// </summary>
        [NotNull]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
