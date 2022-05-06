using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccessor.Entities
{
    [Table("Pictures")]
    public class Pictures : BaseEntity

    {
        public string Name { get; set; }
        public string Link { get; set; }
        public Product Product { get; set; }  
    }


}
