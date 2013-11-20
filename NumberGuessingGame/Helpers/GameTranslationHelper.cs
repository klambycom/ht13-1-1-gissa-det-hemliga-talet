using System;
using System.Collections.Specialized;
using System.Web.Mvc;
using NumberGuessingGame.Models;

namespace NumberGuessingGame.Helpers
{
    public static class GameTranslationHelper
    {
        public static string NumberToSwedish(this HtmlHelper helper, int number)
        {
            string[] swedish = { "Inga", "Första", "Andra", "Tredje", "Fjärde", "Femte", "Sjätte", "Sjunde" };
            return swedish[number];
        }

        public static MvcHtmlString GuessToText(this HtmlHelper helper, GuessedNumber guess)
        {
            var outcome = new OrderedDictionary();
            outcome.Add(Outcome.High, "&darr;");
            outcome.Add(Outcome.Low, "&uarr;");

            return MvcHtmlString.Create(String.Format("{0}, {1}", guess.Number, outcome[guess.Outcome]));
        }
    }
}