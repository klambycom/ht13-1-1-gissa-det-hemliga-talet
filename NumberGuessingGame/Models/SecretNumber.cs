using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumberGuessingGame.Models
{
    public class SecretNumber
    {
        private int? _number;
        public const int MaxNumberOfGuesses = 7;
        private GuessedNumber _lastGuessedNumber;
        private List<GuessedNumber> _guessedNumbers;

        public bool CanMakeGuess
        {
            get
            {
                return Count < MaxNumberOfGuesses && LastGuessedNumber.Outcome != Outcome.Right;
            }
        }

        public int Count
        {
            get
            {
                return _guessedNumbers.Count;
            }
        }

        public IList<GuessedNumber> GuessedNumbers
        {
            get
            {
                return _guessedNumbers.AsReadOnly();
            }
        }

        public GuessedNumber LastGuessedNumber
        {
            get
            {
                return _lastGuessedNumber;
            }
        }

        public int? Number
        {
            get
            {
                if (CanMakeGuess)
                {
                    return null;
                }
                return _number;
            }

            private set
            {
                _number = value;
            }
        }

        public SecretNumber()
        {
            _guessedNumbers = new List<GuessedNumber>(MaxNumberOfGuesses);
            Initialize();
        }

        public void Initialize()
        {
            _guessedNumbers.Clear();

            var rnd = new Random();
            Number = rnd.Next(1, 100);

            _lastGuessedNumber.Number = null;
            _lastGuessedNumber.Outcome = Outcome.Indefinite;
        }

        public Outcome MakeGuess(int guess)
        {
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (!CanMakeGuess)
            {
                return Outcome.NoMoreGuesses;
            }

            var guessedNumber = new GuessedNumber();
            guessedNumber.Number = guess;

            if (GuessedNumbers.Contains(guessedNumber))
            {
                guessedNumber.Outcome = Outcome.OldGuess;
                _lastGuessedNumber = guessedNumber;
                return Outcome.OldGuess;
            }

            if (guess > _number)
            {
                guessedNumber.Outcome = Outcome.High;
            }
            else if (guess < _number)
            {
                guessedNumber.Outcome = Outcome.Low;
            }
            else if (guess == _number)
            {
                guessedNumber.Outcome = Outcome.Right;
            }

            _guessedNumbers.Add(guessedNumber);
            _lastGuessedNumber = guessedNumber;

            return guessedNumber.Outcome;
        }
    }
}