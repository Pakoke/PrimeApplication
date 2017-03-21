using SQLite.Net.Attributes;
using System;

namespace Prime.Common.Dtos
{
    public class PrimeMaterialDto
    {
        [PrimaryKey]
        public string Name { get; set; }
        
        public string Id { get; set; }

        public string Description { get; set; }

        [NotNull]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}