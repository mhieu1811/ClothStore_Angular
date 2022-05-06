using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Contracts.Dtos
{
    public class CommentsDto : BaseDto
    {
        public Guid UserId { get; set; }
        public UserDto User { get; set; }
        public string Comment { get; set; }
        public Guid NewsId { get; set; }
        public ProductDto News { get; set; }
    }
}
