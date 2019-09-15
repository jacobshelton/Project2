using System.Collections.Generic;

namespace GroupBox.Domain.Models
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public List<Group> Groups { get; set; }
        public List<Post> Posts { get; set; }
    }
}