
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public class MyDbContext : DbContext
    {
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public MyDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
    }
}
