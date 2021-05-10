using System;
using System.Collections.Generic;
using System.Text;

namespace KursovoiProectCSharp.Model
{
    public enum MediaType
    {
        Question, Answear
    }

    public class Media
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public byte[] Image { get; set; }
        public MediaType Type { get; set; }
    }
}
