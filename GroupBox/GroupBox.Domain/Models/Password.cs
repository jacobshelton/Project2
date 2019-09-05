namespace GroupBox.Domain.Models
{
    public class Password
    {
        public int ID { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
    }
}