using System.Collections.Generic;

namespace GroupBox.Domain.Models
{
    public class Group
    {
        public Group()
        {
            this.Users = new HashSet<User>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public List<Post> Posts { get; set; }
    }
}