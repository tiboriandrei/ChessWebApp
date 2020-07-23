using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChessWebApp.Data.Entities
{
    public class ChessSeeder 
    {
        private readonly ChessContext _ctx;
        private readonly IWebHostEnvironment _hosting;

        public ChessSeeder(ChessContext ctx, IWebHostEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }
        
        public void Seed() {
            _ctx.Database.EnsureCreated();

            if (!_ctx.Players.Any())
            {                
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/players.json");

                var json = File.ReadAllText(filepath);

                var root = JsonConvert.DeserializeObject<IEnumerable<PlayerJson>>(json);
                var array = new ChessPlayer[root.Count()];

                int i = 0;
                foreach (PlayerJson item in root)
                {
                    array[i] = item.Player;
                    i++;
                }
                _ctx.Players.AddRange(array);

                _ctx.SaveChanges();
            }

        }
    }


}
