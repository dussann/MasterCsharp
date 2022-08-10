using System.Collections.Generic;

namespace StackOverflow.Models
{
    public class Badge
    {
        public int ID { get; set; }
        public ICollection<User> Users { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       
    }
}
