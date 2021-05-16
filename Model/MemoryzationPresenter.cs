using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KursovoiProectCSharp.Model
{
    public class MemoryzationPresenter : NotifyPropertyChanged
    {
        private static List<MemoryzationCategory> categories { get; set; }

        public double AgainInterval
        {
            get { return categories[1].minuteInterval; }
        }

        public double BadInterval
        {
            get { return categories[2].minuteInterval; }
            set
            {
                categories[2].minuteInterval = value;
                OnPropertyChanged("BadInterval");
            }
        }

        public double NormalInterval
        {
            get { return categories[3].minuteInterval; }
            set
            {
                categories[3].minuteInterval = value;
                OnPropertyChanged("NormalInterval");
            }
        }

        public double GoodInterval
        {
            get { return categories[4].minuteInterval; }
            set
            {
                categories[4].minuteInterval = value;
                OnPropertyChanged("GoodInterval");
            }
        }

        public double ExcellentInterval
        {
            get { return categories[5].minuteInterval; }
            set
            {
                categories[5].minuteInterval = value;
                OnPropertyChanged("ExcellentInterval");
            }
        }

        public static bool isTimeTrain(DateTime lastAnswearTime, MemoryzationQuality quality)
        {
            var c = categories.First(e => e.quality == quality);
            var now = DateTime.Now;
            return (now - lastAnswearTime).TotalMinutes > c.minuteInterval;
        }

        static MemoryzationPresenter()
        {
            categories = new List<MemoryzationCategory>
            {
                new MemoryzationCategory() { quality = MemoryzationQuality.No, minuteInterval = 0},
                new MemoryzationCategory() { quality = MemoryzationQuality.Again, minuteInterval = 0.1},
                new MemoryzationCategory() { quality = MemoryzationQuality.Bad, minuteInterval = 0.3},
                new MemoryzationCategory() { quality = MemoryzationQuality.Normal, minuteInterval = 0.9},
                new MemoryzationCategory() { quality = MemoryzationQuality.Good, minuteInterval = 1.8},
                new MemoryzationCategory() { quality = MemoryzationQuality.Excellent, minuteInterval = 5.4},
            };
        }
    }
}
