using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflow.Models
{
    public class AQViewModel
    {
        public Question Question { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
