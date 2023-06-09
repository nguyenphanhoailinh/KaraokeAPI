using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using testAPI.Models;

namespace testAPI.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
       : base(options) { }

       
        #region DbSet
        public DbSet<KaraokeRoom> karaokeRoom { get; set; }
<<<<<<< HEAD
        public DbSet<Users> Users { get; set; }
        public DbSet<Menu> Menu { get; set; }
=======

        public DbSet<Customer> customer { get; set; }
>>>>>>> 64845b6eede57d821eaddce115d2ffd4b5b0d8c7
        #endregion
    }
}
