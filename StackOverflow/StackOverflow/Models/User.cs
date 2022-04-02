using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.Models
{
    
    public class User
    {
        
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Country { get; set; }
        public string JobTitle { get; set; }
        [Required]
        
        public string Password { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}

