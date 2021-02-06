using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;
using Rock.Paper.Scissors;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRoundGame<Move, Round> _game;

        public HomeController(ILogger<HomeController> logger,
        IRoundGame<Move, Round> game)
        {
            _logger = logger;
            _game = game;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Play([FromBody]UserRound model)
        {
            _logger.LogInformation($"User Move {model.UserMove}");

            _game.AddUserMove((Move)model.UserMove);

            return Json(new { Rows = _game.Rounds });
        }

        [HttpPost]
        public IActionResult Reset()
        {
            _logger.LogInformation($"Reset game");
            _game.Reset();
            return Json(true);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
