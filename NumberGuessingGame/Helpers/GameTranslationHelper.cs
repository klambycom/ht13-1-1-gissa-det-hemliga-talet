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

        public static string HighOrLow(this HtmlHelper helper, GuessedNumber guess, string high, string low)
        {
            return guess.Outcome == Outcome.High ? high : low;
        }
    }
}