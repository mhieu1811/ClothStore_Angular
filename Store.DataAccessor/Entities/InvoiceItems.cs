using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccessor.Entities
{

    [Table("InvoiceItem")]
    public class InvoiceItems : BaseEntity
    {
        public Guid InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
