using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NumberGuessingGame.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Providers.Entities;
using System.ComponentModel;

namespace NumberGuessingGame.ViewModels
{
    public class Game
    {
        public SecretNumber SecretNumber { get; set; }

        [Required]
        [DisplayName("Gissa ett tal mellan 1 och 100:")]
        public int Guess { get; set; }
    }
}