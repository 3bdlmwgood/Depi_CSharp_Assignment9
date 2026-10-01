namespace Assignment9
{
    internal class Program
    {
        static void Section1()
        {
            List<Book> books = new List<Book>()
            {
                new Book("978-3-16-148410-0", "The Great Gatsby", new string[] { "F. Scott Fitzgerald, William Faulkner" }, new DateTime(1925, 4, 10), 10.99m),
                new Book("978-0-7432-7356-5", "To Kill a Mockingbird", new string[] { "Harper Lee , John Steinbeck" }, new DateTime(1960, 7, 11), 7.99m)
            };


            Console.WriteLine("Titles:");
            LibraryEngine.ProcessBooks_UserDefined(books, BookFunctions.GetTitle);
            LibraryEngine.ProcessBooks_BuiltIn<string>(books, BookFunctions.GetTitle);
            Console.WriteLine();

            Console.WriteLine("Authors:");
            LibraryEngine.ProcessBooks_UserDefined(books, BookFunctions.GetAuthors);
            LibraryEngine.ProcessBooks_BuiltIn<string>(books, BookFunctions.GetAuthors);
            Console.WriteLine();

            Console.WriteLine("ISBNs:");
            LibraryEngine.ProcessBooks_UserDefined(books, delegate (Book B) { return B.ISBN;});
            LibraryEngine.ProcessBooks_BuiltIn<string>(books, delegate (Book B) { return B.ISBN;});
            Console.WriteLine();

            Console.WriteLine("Publication Dates:");
            LibraryEngine.ProcessBooks_BuiltIn<DateTime>(books, book => book.PublicationDate);
            Console.WriteLine();
        }
        
        static void Main(string[] args)
        {
            Section1();
        }
    }
}