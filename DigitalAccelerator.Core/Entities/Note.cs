namespace DigitalAccelerator.API.Entities
{
    public class Note
    {
        //public int Id { get; private set; }
        //public string Author { get; private set; } = string.Empty;
        //public string? Content { get; private set; } = string.Empty;

        public int Id { get; set; }
        public string Author { get; set; } = string.Empty;
        public string? Content { get; set; } = string.Empty;

        public Note(string author, string content)
        {
            Author = author;
            Content = content;
        }
        //create public void method to set author/set content, call in update method

    }
}
