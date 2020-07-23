using ChessWebApp.Data.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ChessWebApp.Data
{
    public class ChessContext : DbContext 
    {
        public ChessContext(DbContextOptions<ChessContext> options) : base(options)
        {
            
        }

        public DbSet<ChessGame> Games { get; set; }
        public DbSet<ChessPlayer> Players { get; set; }
    }
}
