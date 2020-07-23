using ChessWebApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//not used
namespace ChessWebApp.Data
{
    public class ChessContextFactory : IDesignTimeDbContextFactory<ChessContext>
    {
        private readonly IConfiguration _config = MyAppData.Configuration;

        public ChessContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ChessContext>();

            //optionsBuilder.UseSqlite("Data Source=blog.db");
            optionsBuilder.UseSqlServer(_config.GetConnectionString("ChessConnectionString"));

            return new ChessContext(optionsBuilder.Options);
        }

        public DbSet<ChessGame> Games { get; set; }
        public DbSet<ChessPlayer> Players { get; set; }
    }
}
