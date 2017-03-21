using SQLite.Net.Attributes;
using System;

namespace Prime.Common.Dtos
{
    public class ShopDto
    {
        public ShopDto() { }

        [PrimaryKey]
        public string Location { get; set; }

        public string LinkMap { get; set; }

        [NotNull]
        public UserDto Owner { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}