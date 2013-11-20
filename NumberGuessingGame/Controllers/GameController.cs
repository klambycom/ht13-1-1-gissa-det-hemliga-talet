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
        private Game game = new Game();

        private SecretNumber GetSecretNumber()
        {
            var sessionName = "SecrectNumberSession";

            if (Session[sessionName] == null)
            {
                Session[sessionName] = new SecretNumber();
            }

            return (SecretNumber)Session[sessionName];
        }

        //
        // GET: /Game/

        public ActionResult Index()
        {
            game.SecretNumber = GetSecretNumber();
            return View(game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include="Guess")]Game guessedNumber)
        {
            if (ModelState.IsValid)
            {
                game.SecretNumber = GetSecretNumber();
                game.SecretNumber.MakeGuess(guessedNumber.Guess);
                Session["SecretNumber"] = game.SecretNumber;
            }

            return View(game);
        }
    }
}
