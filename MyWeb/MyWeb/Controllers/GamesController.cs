using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Models;
using MyWeb.ViewModels;

namespace MyWeb.Controllers
{
    public class GamesController : Controller
    {
        private Models.AppContext _context = new Models.AppContext();

        // GET: Games
        public ActionResult Play()
        {
            var game = new Games();
            game.Name = "Play Back 3";
            return View(game);
        }
        [Route("Games")]
        public ActionResult Index()
        {
            var games = _context.Games.ToList();

            var gamesList = new RandomMovieViewModel()
            {
                Games = games
            };
            return View(gamesList);
        }
        [Route("Games/{id}")]
        public ActionResult Game(int id)
        {
            return View(_context.Games.Find(id));
        }
    }
}