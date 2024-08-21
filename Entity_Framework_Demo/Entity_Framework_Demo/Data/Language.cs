namespace Entity_Framework_Demo.Data
{
    public class Language
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<Books> Books { get; set; } = new List<Books>();
    }
}
