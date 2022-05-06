using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccessor.Entities
{

    [Table("Type")]
    public class Type : BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 200)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Desc { get; set; }
        public ICollection<Product> Product { get; set; }


    }
}
