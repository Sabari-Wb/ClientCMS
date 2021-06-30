using ClientCMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientCMS.Data
{
    public class CMSClientContext:DbContext
    {
        public CMSClientContext(DbContextOptions<CMSClientContext> options)
            : base(options)
        {

        }
       public DbSet<User>Users { get; set; }

      
    }
}
