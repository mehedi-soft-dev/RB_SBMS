using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecycleBin.Model.Model;

namespace RecycleBin.DatabaseContext.DatabaseContext
{
    public class ProjectDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
    }
}
