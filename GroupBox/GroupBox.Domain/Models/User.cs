using System.Collections.Generic;

namespace GroupBox.Domain.Models
{
    public class User
    {
        public User()
        {
            this.Groups = new HashSet<Group>();
        }
        public int ID { get; set; }
        public string UserName { get; set; }
        public Password Password { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public List<Post> Posts { get; set; }
    }
}