using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumberGuessingGame.Models
{
    public struct GuessedNumber : IEquatable<GuessedNumber>
    {
        public int? Number;
        public Outcome Outcome;

        public bool Equals(GuessedNumber other)
        {
            return this.Number == other.Number;
        }
    }
}