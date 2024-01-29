using oopConcepts;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            Transaction transaction = new Transaction();

            Book book1 = new Book("Book 1","Author 1" );
            Book book2 = new Book("Book 2", "Author 2" );

            Console.WriteLine();

            Staff user1 = new Staff ( "User 1" , "librarian" );
            Reader user2 = new Reader ("User 2" , 12345);
            Reader user3 = new Reader("User 3", 0987654, "Lost Books");

            Console.WriteLine();

            library.AddBook(book1); 
            library.AddBook(book2);

            Console.WriteLine();

            library.AddUser(user1);
            library.AddUser(user2);

            Console.WriteLine();
            Console.WriteLine("---------- Display all Books -------------");
            library.DisplayBookInfo();

            Console.WriteLine();

            Console.WriteLine("---------- Display all Users -------------");
            library.DisplayAllUsers();

            Console.WriteLine();
            Console.WriteLine("---------- Borrowed books -----------");

            library.BorrowBook(book1, user1);
            library.BorrowBook(book2, user2);

            Console.WriteLine();
            Console.WriteLine("-------------Display all Transactions ----------------");

            library.DisplayAllTransactions();

            Console.WriteLine();
            Console.WriteLine("---------- Return Books ---------------");

            library.ReturnBook(1);

            Console.WriteLine();
            Console.WriteLine("--------- Display all books ----------------");

            library.DisplayBookInfo();

            Console.WriteLine("-------- violations --------------");

            LostBookViolation lostBookViolation = new LostBookViolation((decimal)500.0);
            library.DisplayViolation(lostBookViolation);

            MisplacedBookViolation misplacedBookViolation = new MisplacedBookViolation(2, (decimal)250.0 , library);
            library.DisplayViolation(misplacedBookViolation);

            OtherViolation otherViolation = new OtherViolation((decimal)100.0);
            library.DisplayViolation(otherViolation);       

        }
    }
}
