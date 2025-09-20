namespace LibraryManagementSystem.Domain;

public class Author : BaseModel
{
    // DO NOT MODIFY ABOVE THIS LINE
    // TODO: 4.1 Add public Name property here with type 'string?' (nullable string)
    public string? Name { get; set; }
    // TODO: 4.2 Add public Books property here with type 'ICollection<Book>' (collection of Book)
    // An author may have written multiple books.
    // This will make the relationship between Book and Author many-to-many
    public ICollection<Book> Books { get; set; } = new List<Book>();

    // DO NOT MODIFY BELOW THIS LINE

    public string BooksToString()
    {
        // DO NOT MODIFY ABOVE THIS LINE
        // This method should return a string with the names of the books of the author separated by commas
        // If the author has multiple books, the names should be separated by commas and the last name should be preceded by 'and'
        // If the author has only one book, the name should be returned as is
        // If the author has no books, an empty string should be returned
        // TODO: 4.3 Implement the BooksToString method
        // throw new NotImplementedException("Author.BooksToString is not implemented");
        // Handle edge cases
            if (Books == null || !Books.Any())
            {
                return string.Empty;
            }

            // Get book titles
            var bookTitles = Books
                .Select(book => book.Title)
                .Where(title => !string.IsNullOrEmpty(title))
                .ToList();

            if (!bookTitles.Any())
            {
                return string.Empty;
            }

            // Handle single book
            if (bookTitles.Count == 1)
            {
                return bookTitles[0];
            }

            // Handle multiple books: "Book1, Book2 and Book3"
            if (bookTitles.Count == 2)
            {
                return $"{bookTitles[0]} and {bookTitles[1]}";
            }

            // More than 2 books
            var allButLast = string.Join(", ", bookTitles.Take(bookTitles.Count - 1));
            var lastBook = bookTitles.Last();
            return $"{allButLast} and {lastBook}";
        // DO NOT MODIFY BELOW THIS LINE
    }
}