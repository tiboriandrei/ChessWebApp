using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChessWebApp.Models;
using ChessClassLibrary;

namespace ChessWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        Game chessGame;  //maybe put it in a class (ex: globalVar.cs)
        public IActionResult StartNewChessGame()
        {
            Game chessGame = new Game();

            return View();
        }

        [HttpPost]
        public IActionResult TryMove(int originColumn, int originRow, int destColumn, int destRow, string player, string piece)
        {
            chessGame.Table.MovePiece(piece, originColumn, originRow, destColumn, destRow, player);

            return View();
        }
    }
}
