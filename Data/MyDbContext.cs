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
        #endregion
    }
}
