using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccessor.Entities
{

    [Table("Invoice")]
    public class Invoice : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<InvoiceItems> Items { get; set; }

    }
}
