using System;
using System.Collections.Generic;

namespace StackOverflow.Models
{
    public class Answer
    {      
        public int ID { get; set; }
        public int QuestionID { get; set; }
        public Question Question { get; set; }
        
        
        public string Content { get; set; }
        public short Raiting { get; set; }
        public User User { get; set; }
        public int UserID { get; set; }

        
        public ICollection<Answer> Comments { get; set; } = new List<Answer>();

        public Guid? ParentAnswerId { get; set; }
        public Answer OriginalText { get; set; }
    }
}
