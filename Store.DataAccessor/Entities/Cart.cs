using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccessor.Entities
{

    [Table("Cart")]
    public class Cart : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<CartItems> Items { get; set; }

    }
}
