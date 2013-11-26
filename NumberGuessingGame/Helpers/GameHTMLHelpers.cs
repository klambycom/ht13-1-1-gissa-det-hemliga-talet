using System;
using System.Collections.Specialized;
using System.Web.Mvc;
using NumberGuessingGame.Models;
using System.Linq.Expressions;
using System.Web.Mvc.Html;

namespace NumberGuessingGame.Helpers
{
    public static class GameHTMLHelpers
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

        public static MvcHtmlString GuessTextBoxFor<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            GuessedNumber number)
        {
            if (number.Outcome == Outcome.NoMoreGuesses)
                return helper.TextBoxFor(expression, new { disabled = "", Value = number.Number });

            return helper.TextBoxFor(expression, new { autofocus = "", Value = number.Number });
        }
    }
}