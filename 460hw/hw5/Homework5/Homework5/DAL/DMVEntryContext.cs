using System;
using System.Data.Entity;
using Homework5.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework5.DAL
{
    public class DMVEntryContext : DbContext
    {
        //Set the name for the dbContext element. This will apear in the Web.config file.
        public DMVEntryContext() : base("name=MyDB")
       {}

        //Create the list of records within the database.
        public virtual DbSet<DMVEntry> DMVEntries { get; set; }

    }
}