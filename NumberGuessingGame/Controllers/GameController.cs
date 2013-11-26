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
        private String sessionName = "SecrectNumberSession";

        public Game Game {
            get
            {
                var game = new Game();

                if (Session[sessionName] == null)
                {
                    Session[sessionName] = new SecretNumber();
                }
                game.SecretNumber = (SecretNumber)Session[sessionName];

                return game;
            }
        }

        // Show game outcome
        // GET: /Game/

        public ActionResult Index()
        {
            if (Game.SecretNumber.CanMakeGuess)
            {
                return View(Game);
            }
            else if (Game.SecretNumber.LastGuessedNumber.Outcome == Outcome.Right)
            {
                return View("CorrectGuess", Game);
            }

            return View("GameLost", Game);
        }

        // Save guess and redirect to front page
        // POST: /Game/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include="Guess")]Game guessedNumber)
        {
            if (ModelState.IsValid)
            {
                Game.SecretNumber.MakeGuess(guessedNumber.Guess);

                if (Session.IsNewSession)
                {
                    return View("OldSession");
                }

                return RedirectToAction("Index");
            }

            return View(Game);
        }

        // Destroy session and redirect to front page
        // GET: /Game/New/

        public ActionResult New()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
