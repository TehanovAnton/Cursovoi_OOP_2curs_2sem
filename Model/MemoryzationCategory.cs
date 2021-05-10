using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace KursovoiProectCSharp.Model
{
    public enum MemoryzationQuality
    {
        No, Again, Bad, Normal, Good, Excellent 
    }

    public class MemoryzationCategory
    {
        public static List<MemoryzationCategory> categories { get; set; }

        private MemoryzationQuality quality { get; set; }
        private double minuteInterval { get; set; }

        public static bool isTimeTrain(DateTime lastAnswearTime, MemoryzationQuality quality)
        {
            var c = categories.First(e => e.quality == quality);
            var now = DateTime.Now;
            return (now - lastAnswearTime).TotalMinutes > c.minuteInterval;
        }

        static MemoryzationCategory()
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
