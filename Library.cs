using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopConcepts
{
    public class Library
    {
        public List<Book> books = new List<Book>(); 
        public List<User> users = new List<User>();
        public List<Transaction> transactions = new List<Transaction>();

        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine("Add to book list");
        }

        public void AddUser(User user) 
        {
            users.Add(user);
            Console.WriteLine("Add to user list");
        }

        public void BorrowBook(Book book , User user)
        {
            if(!book.availabilty)
            {
                Console.WriteLine("Sorry, the book is not available.");
            }
            else
            {
                book.availabilty = false;
                Transaction transactionDet = new Transaction(book, user);
                if (transactionDet != null)
                {
                    transactions.Add(transactionDet);
                    Console.WriteLine("Transaction Completed.");
                }
                else
                    Console.WriteLine("Transaction unsuccessful");
            }
        }


        public void ReturnBook(int transactionID)
        {
            foreach (Transaction transaction in transactions) 
            {
                if(transaction.transactionId == transactionID)
                { 
                    transaction.ReturnBook(transactionID);
                }
            }
        }

        public void DisplayBookInfo()
        {
            foreach(Book book in books) 
            {
                string bookName = book.title; 
                book.DisplayBook(bookName);
                Console.WriteLine();
            }
        }

        public void DisplayAllUsers()
        {
            foreach (User user in users)
            {
                user.DisplayUserInfo();
                Console.WriteLine();
            }
        }

        public void DisplayAllTransactions()
        {
            foreach(Transaction transaction in transactions)
            {
                Console.WriteLine("display transaction");
                int transactionId = transaction.transactionId;
                transaction.DisplayTransactionDetails(transactionId);
                Console.WriteLine();
            }
        }
    }
}
