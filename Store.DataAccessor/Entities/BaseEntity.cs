using System;
using System.ComponentModel.DataAnnotations;

namespace Store.DataAccessor.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool Published { get; set; }
    }
}
