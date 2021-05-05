using System;
using System.Collections.Generic;
using System.Text;
using KursovoiProectCSharp.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KursovoiProectCSharp
{
    public class DB
    {
        public static ApplicationContext context;
        static DB()
        {
            context = new ApplicationContext();
        }

        public static bool IsUser(string password, string nickname)
        {
            return context.Users.Where(u => u.Password == password && u.NickName == nickname).ToList().Count == 1;
        }

        public static bool IsDeck(string title, string password, string nickname)
        {
            var u = context.Users.Where(u => u.Password == password && u.NickName == nickname).ToList();
            return context.Decks.Where(d => d.Title == title && d.UserId == u[0].Id).ToList().Count == 1;
        }
    }
}
