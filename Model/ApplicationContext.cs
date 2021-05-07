using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Text;

namespace KursovoiProectCSharp.Model
{
    public class ApplicationContext : DbContext, INotifyPropertyChanged
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UsersInfo { get; set; }


        private DbSet<Deck> decks;
        public DbSet<Deck> Decks
        {
            get { return decks; }
            set
            {
                decks = value;
                OnPropertyChanged("Decks");
            }
        }

        public DbSet<Card> Cards { get; set; }

        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
