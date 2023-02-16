using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Articles")]
    public class Journalist
    {
        public int Id {get; set;}
        public string UserName {get; set;}   
        public byte[] PasswordHash {get; set;}
        public byte[] PasswordSalt {get; set;}
        public DateOnly DateOfBirth {get; set;}
        public DateTime Created {get; set;} = DateTime.UtcNow;
        public string City {get; set;}
        public string Country {get; set;}
        public List<Article> Articles {get; set;} = new();

    }
}