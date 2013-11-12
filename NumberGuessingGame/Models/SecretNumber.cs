using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumberGuessingGame.Models
{
    public class SecretNumber
    {
        private int? _number;
        private int MaxNumberOfGuesses;

        public bool CanMakeGuess
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IList<GuessedNumber> GuessedNumbers
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public GuessedNumber LastGuessedNumber
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int? Number { get; set; }

        public SecretNumber()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public Outcome MakeGuess(int guess)
        {
            throw new NotImplementedException();
        }
    }
}