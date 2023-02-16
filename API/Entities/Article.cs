namespace API.Entities
{
    public class Article
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public string Description {get; set;}
        public string Content {get; set;}      

        public int JournalistId {get; set;}
        public Journalist Journalist {get; set;}  
    }
}