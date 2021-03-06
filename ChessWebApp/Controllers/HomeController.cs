﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChessWebApp.Models;
using ChessClassLibrary;
using Newtonsoft.Json;
using ChessWebApp.Data;
using ChessWebApp.Data.Entities;
using ChessClassLibrary.Players;

namespace ChessWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ChessAppRepository _repository;

        public HomeController(ChessAppRepository repository)
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
            //Player player1 = _repository.GetPlayerByID(10);
            //Player player2 = _repository.GetPlayerByID(11);

            //Game chessGame = new Game();

            //_repository.AddGame(chessGame);
            
            return View("ChessGame");
        }

        public IActionResult StartNewChessGame()
        {
            return View();
        }

        public static int hardcodedGetGameID = 35;


        [HttpPost]
        public JsonResult BlackMove(int originColumn, int originRow, int destColumn, int destRow, string player, string piece) {

            Game returnedGame = _repository.GetGameByID(hardcodedGetGameID);

            var origin = new Spot(originColumn - 1, originRow - 1);
            var dest = new Spot(destColumn - 1, destRow - 1);

            returnedGame.Black.DoAMove(origin, dest);

            string moveResult = returnedGame.MoveResult;
            if (moveResult == "goodMove")
            {
                _repository.UpdateGame(hardcodedGetGameID, originColumn - 1, originRow - 1, destColumn - 1, destRow - 1, player, piece);
            }

            return Json(moveResult);
        }


        [HttpPost]
        public JsonResult WhiteMove(int originColumn, int originRow, int destColumn, int destRow, string player, string piece)
        {            
            try
            {
                Game returnedGame = _repository.GetGameByID(hardcodedGetGameID);

                var origin = new Spot(originColumn - 1, originRow - 1);
                var dest = new Spot(destColumn - 1, destRow - 1);
                              
                returnedGame.White.DoAMove(origin, dest);                

                string moveResult = returnedGame.MoveResult;                
                if (moveResult == "goodMove")
                {
                    _repository.UpdateGame(hardcodedGetGameID, originColumn - 1, originRow - 1, destColumn - 1, destRow - 1, player, piece);
                }
                
                return Json(moveResult); 
            }
            catch (Exception ex)
            {
                return Json("something went wrong");
            }
        }

        [HttpGet]
        public JsonResult LoadGameState()
        {
            GameStateForJS[] gameState = _repository.LoadGameState(hardcodedGetGameID);
            string output = JsonConvert.SerializeObject(gameState);

            return Json(output);
        }
    }
}
