
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccessor.Entities
{
    [Table("Product")]
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public Guid TypeID { get; set; }
        public Type Type { get; set; }
        public IEnumerable<Pictures> Pictures { get; set; }
        public IEnumerable<Comments> Comments { get; set; }
        public IEnumerable<CartItems> CartItems { get; set; }



    }
}
