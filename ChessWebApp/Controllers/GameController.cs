using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessGameRepository.Interface;
using ChessGameRepo.Services;
using Microsoft.AspNetCore.Mvc;
using ChessClassLibrary;
using ChessWebApp.Data;

namespace ChessWebApp.Controllers
{
    //[Route("api/[Controller]")]
    //[ApiController]
    //[Produces("application/json")]
    public class GameController : Controller
    {
        private readonly IChessGameRepository _repository;        

        public GameController(IChessGameRepository repository)
        {
            _repository = repository;            
        }

        public IActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult Save() {
            return View();
        }

        [HttpPost]
        public IActionResult GetPlayer(int id)
        {
            var results = _repository.GetPlayerByID(id);
            return View();
        }

        [HttpPost]
        public IActionResult Move(int originColumn, int originRow, int destColumn, int destRow, string player, string piece)
        {
            Console.WriteLine();

            try
            {
                Game returnedGame = _repository.GetGameByID(1);
                returnedGame.MovePiece(piece, originColumn, originRow, destColumn, destRow, player);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest("Can't execute move");
            }

        }

        


    }
}