using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities.Common
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public Guid CreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? UpdatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? DeletedUserId { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
