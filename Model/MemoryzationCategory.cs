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

    public class MemoryzationCategory : NotifyPropertyChanged
    {
        public MemoryzationQuality quality { get; set; }
        public double minuteInterval { get; set; }
    }
}
