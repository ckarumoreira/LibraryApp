namespace LibraryApp.Application.ViewModels
{
    public class BookViewModel
    {
        public string Author { get; set; }
        public int Id { get; set; }

        public bool IsAvailable { get; set; }

        public string Title { get; set; }
    }
}