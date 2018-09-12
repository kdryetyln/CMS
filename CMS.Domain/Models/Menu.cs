using CMS.Domain.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Models
{
    public class Menu:BaseEntity
    {    
        public Page Page { get; set; }
        public int PageId { get; set; }
        public Menu Menus { get; set; }
        public int? MenuId { get; set; }
    }
}
