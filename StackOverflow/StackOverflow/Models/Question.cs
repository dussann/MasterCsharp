using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflow.Models
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public User User { get; set; }
        public int UserID { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
