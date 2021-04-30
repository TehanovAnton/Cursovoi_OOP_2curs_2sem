using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KursovoiProectCSharp.Model
{
    public class UserInfo
    {
        // валидация на основании анотаций
        public int Id { get; set; }
        public string Fio { get; set; }
        public string Mail { get; set; }
        public byte[] ImageBytes { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
