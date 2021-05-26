using System;
using System.Collections.Generic;
using System.Text;
using KursovoiProectCSharp.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using KursovoiProectCSharp.ViewModel;

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
        public static User getUser(string password, string nickname)
        {
            var u = context.Users.First(u => u.Password == password && u.NickName == nickname);
            return u;
        }
        public static int getUserId(string password, string nickname)
        {
            return context.Users.Where(u => u.Password == password && u.NickName == nickname).Select(u => u.Id).ToList()[0];
        }
        public static UserInfo getUserInfo(int userId)
        {
            var exist = context.UsersInfo.Where(u => u.UserId == userId).Count() == 1;
            return exist ? context.UsersInfo.First(u => u.UserId == userId) : new UserInfo();
        }
        public static List<User> getSavedUsers()
        {
            var savedList = context.Users.Where(i => i.SavedLog).ToList();
            foreach (User user in savedList)
            {
                var ui = context.UsersInfo.First(i => i.UserId == user.Id);
                user.UserInfo = ui;        
            }    

            return savedList;
        }


        public static void saveLog(bool SavePassword, User user)
        {
            if (!user.SavedLog)
            {
                user.SavedLog = SavePassword;
                context.SaveChanges();
            }
        }
        public static void saveUserInfo(UserInfo userInfo)
        {
            context.UsersInfo.Add(userInfo);
            context.SaveChanges();
        }
        public static void changeUserInfo(int userId, UserInfo newUserInfo)
        {
            var ui = context.UsersInfo.First(i => i.UserId == userId);

            ui.Fio = newUserInfo.Fio;
            ui.Mail = newUserInfo.Mail;
            ui.BirthDate = newUserInfo.BirthDate;
            ui.ImageBytes = newUserInfo.ImageBytes;

            context.SaveChanges();
        }
        public static void changeUser(int userId, User newUser)
        {
            var u = context.Users.First(us => us.Id == userId);

            u.Password = newUser.Password;
            u.NickName = newUser.NickName;

            context.SaveChanges();
        }


        public static bool IsDeck(string title, string password, string nickname)
        {
            var u = context.Users.Where(u => u.Password == password && u.NickName == nickname).ToList();
            return context.Decks.Where(d => d.Title == title && d.UserId == u[0].Id).ToList().Count == 1;
        }
        public static void addDeck(Deck deck)
        {
            context.Decks.Add(deck);
            context.SaveChanges();
        }
        public static List<Deck> getDecks(int userId)
        {
            return context.Decks.Where(d => d.UserId == userId).ToList();
        }
        public static void removeDeck(Deck deck)
        {
            //удалить все катрточки
            foreach (Card c in getCards(deck))
                context.Cards.Remove(c);

            //удалить колоду
            if (deck != null && DB.context.Decks.Where(d => d.Title == deck.Title).ToList().Count != 0)
                DB.context.Decks.Remove(deck);
            
            DB.context.SaveChanges();
        }
        public static int getDeckTotalCardCount(int deckId)
        {
            return context.Cards.Where(c => c.DeckId == deckId).ToList().Count;
        }
        public static int getDeckTrainingCardCount(int deckId)
        {
            return context.Cards.Where(c => c.DeckId == deckId).ToList().Count;
        }
        public static ObservableCollection<Deck> FindDeck_SimilarTitle(string title, int userId)
        {
            var decks = title == "" ? new List<Deck>() : context.Decks.Where(d => d.Title.StartsWith(title) && d.UserId == userId).ToList();
            return new ObservableCollection<Deck>(decks);
        }


        public static void addCard(Card card)
        {
            context.Cards.Add(card);
            context.SaveChanges();
        }
        public static List<Card> getCards(Deck deck)
        {
            if (deck != null)
                return context.Cards.Where(c => c.DeckId == deck.Id).ToList();
            else
                return new List<Card>();
        }
        public static void removeCard(Card card)
        {
            var medias = context.Medias.Where(m => m.Id == card.QuestionMediaId || m.Id == card.AnswearMediaId).ToList();
            foreach (Media m in medias)
                context.Medias.Remove(m);
            context.Cards.Remove(card);
            context.SaveChanges();
        }
        public static Card getTrainCard(int deckId)
        {
            var trainCards = context.Cards.Where(c => c.DeckId == deckId).ToList()
                .Where(c => MemoryzationPresenter.isTimeTrain(c.lastAnswearTime, c.Quality)).ToList();

            Card c = trainCards.Count != 0 ? trainCards[0] : null;
            return c;
        }
        public static void changeMemoryzationCategory(Card card, MemoryzationQuality quality)
        {
            card.Quality = quality;
            context.SaveChanges();
        }        
        public static Media getMedia(int mediaId)
        {
            var media = context.Medias.First(m => m.Id == mediaId);
            return media;
        }
    }
}
