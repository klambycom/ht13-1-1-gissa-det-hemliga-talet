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

        [Required(ErrorMessage = "Du måste göra en gissning.")]
        [Range(1, 100, ErrorMessage = "Talet måste vara mellan 1 och 100.")]
        [DisplayName("Gissa ett tal mellan 1 och 100: ")]
        public int Guess { get; set; }
    }
}