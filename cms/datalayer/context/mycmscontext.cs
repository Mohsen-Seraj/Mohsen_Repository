
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace datalayer
{
   public class mycmscontext:DbContext
    {

      
        
        public DbSet<pagegroup> pagegroups { get; set; }

        public DbSet<page> pages { get; set; }

        public DbSet<pagecomment> pagecomments { get; set; }

     


    }
}
