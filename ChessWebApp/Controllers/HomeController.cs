using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChessWebApp.Models;
using ChessClassLibrary;
using Newtonsoft.Json;
using ChessWebApp.Data;

namespace ChessWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IChessAppRepository _repository;
        
        public HomeController(IChessAppRepository repository)
        {
            _repository = repository;
        }

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

        public IActionResult ChessGame()
        {
            Player player1 = _repository.GetPlayerByID(10);
            Player player2 = _repository.GetPlayerByID(11);

            Game chessGame = new Game(player1, player2);
            //_repository.AddGame(chessGame);
            //Game returnedGame = _repository.GetGameByID(7);
            return View("ChessGame");
        }

        public IActionResult StartNewChessGame()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Move(int originColumn, int originRow, int destColumn, int destRow, string player, string piece)
        {
            Console.WriteLine();

            try
            {
                Game returnedGame = _repository.GetGameByID(13);
                bool goodMove = returnedGame.MovePiece(piece, originColumn-1, originRow-1, destColumn-1, destRow-1, player);

                if (goodMove)
                {
                    //updategame
                }

                return Json(goodMove); 
            }
            catch (Exception ex)
            {
                return Json("bad move");
            }

        }












        //[HttpPost]        
        //public IActionResult TryMove2(int originColumn, int originRow, int destColumn, int destRow, string player, string piece)
        //{
        //   // chessGame.MovePiece(piece, originColumn, originRow, destColumn, destRow, player);
        //    return View();
        //}

        ////private readonly IGameRepository gameRepository;

        //public IActionResult TryMove(int originColumn, int originRow, int destColumn, int destRow, string player, string piece)
        //{

        //    Game chessGame = new Game();
        //    //get game form db, save it whatever           

        //    bool result = chessGame.MovePiece(piece, originColumn, originRow, destColumn, destRow, player);
        //    //return Json(result);
        //    return View();
        //}


    }
}
