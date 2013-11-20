using NumberGuessingGame.Models;
using NumberGuessingGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NumberGuessingGame.Controllers
{
    public class GameController : Controller
    {
        private Game game;

        public GameController()
        {
            game = new Game();

            try
            {
                game.SecretNumber = Session["SecretNumber"] as SecretNumber;
            }
            catch (Exception)
            {
                game.SecretNumber = new SecretNumber();
            }
        }

        //
        // GET: /Game/

        public ActionResult Index()
        {
            return View(game);
        }

        [HttpPost]
        public ActionResult Index(/*[Bind(Include="Guess")]*/Game guess)
        {
            var req = Request["Guess"];
            //if (ModelState.IsValid)
            //{
                game.SecretNumber.MakeGuess(guess.Guess);
                Session["SecretNumber"] = game.SecretNumber;
            //}

            return View(game);
        }
    }
}
