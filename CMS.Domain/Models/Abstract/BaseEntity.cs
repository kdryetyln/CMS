using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Models.Abstract
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
