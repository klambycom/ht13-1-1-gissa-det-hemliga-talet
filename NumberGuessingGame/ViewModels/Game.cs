using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NumberGuessingGame.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Providers.Entities;

namespace NumberGuessingGame.ViewModels
{
    public class Game
    {
        public SecretNumber SecretNumber { get; set; }

        [Required]
        public int Guess { get; set; }
    }
}