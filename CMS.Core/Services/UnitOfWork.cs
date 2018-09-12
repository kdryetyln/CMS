using CMS.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Services
{
    public class UnitOfWork
    {
        public CMSDbContext Current { get { return new CMSDbContext(); } }
    }
}
