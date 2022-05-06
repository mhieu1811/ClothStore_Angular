using Store.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccessor.Entities
{
    [Table("Comments")]
    public class Comments: BaseEntity
    {
        public Guid  UserId { get; set; }
        public User User { get; set; }
        public string Comment { get; set; }
        public Guid NewsId { get; set; }
        public Product Product { get; set; }
    }
}
