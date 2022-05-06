using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Contracts.Dtos
{
    public class ProductDto:BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public Guid TypeID { get; set; }
        public string AuthorName { get; set; }
        public IEnumerable<CommentsDto> Comments { get; set; }
    }
}
