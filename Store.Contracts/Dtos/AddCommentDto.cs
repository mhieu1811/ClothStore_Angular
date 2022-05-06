using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Contracts.Dtos
{
    public class AddCommentDto
    {
        [Required]
        public string Comment { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid NewsId { get; set; }
    }
}
