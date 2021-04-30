using System;
using System.Collections.Generic;
using System.Text;

namespace KursovoiProectCSharp.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public UserInfo Info { get; set; }

        public User(string password, string nickName)
        {
            Password = password;
            NickName = nickName;
        }

        public User() { }
    }
}
