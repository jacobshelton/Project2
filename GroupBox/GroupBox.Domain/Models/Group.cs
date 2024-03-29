using System.Collections.Generic;

namespace GroupBox.Domain.Models
{
    public class Group
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public List<Post> Posts { get; set; }

        public Group()
        {
            Users = new List<User>();
            Posts = new List<Post>();
        }
    }
}