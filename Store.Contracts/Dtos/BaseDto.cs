using System;

namespace Store.Contracts.Dtos
{
    public class BaseDto
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public Guid? CreatorId { get; set; }

        public bool Published { get; set; }
    }
}
