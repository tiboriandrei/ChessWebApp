using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace ChessWebApp.Data
{
    public static class RepositoryFactory
    {
        public static IChessGameRepository GetRepository(string repositoryType, ChessContext _ctx) {
            
            string repositoryTypeName = ConfigurationManager.AppSettings["RepositoryType"];

            //
            
            IChessGameRepository repository = null;

            switch (repositoryType)
            {
                case "EF": repository = new ChessAppRepository(_ctx); break;
                default: throw new ArgumentException("Invalid repo type");
            }

            return repository;

        }
    }
}
