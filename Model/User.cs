using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KursovoiProectCSharp.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public bool SavedLog { get; set; }
        public List<Deck> Decks { get; set; }        
        public UserInfo UserInfo { get; set; }

        public User()
        {
            Decks = new List<Deck>();
        }
    }
}
