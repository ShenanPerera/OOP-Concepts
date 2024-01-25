using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopConcepts
{
    public class Transaction
    {
        private static readonly Random R = new Random();
        private static int nextTransactionId = 0;
        public int transactionId { get; set; }
        public Book borrowedBook { get; set; }
        public User borrowedUser { get; set; }  
        public DateTime borrowedDate { get; set; }
        public DateTime returnDate { get; set; }

        public Transaction(Book book , User user)
        {
            transactionId = GenerateID();
            this.borrowedBook = book;
            this.borrowedUser = user;
            borrowedDate = DateTime.Now;
            returnDate = borrowedDate.AddDays(3);
        }

        public int GenerateID()
        {
            return Interlocked.Increment(ref nextTransactionId);
        }

        public void DisplayTransactionDetails(int id)
        {
            if (transactionId == id)
            {
                Console.WriteLine($"Transaction ID : {transactionId}");
                Console.WriteLine($"Book : {borrowedBook.title}");
                Console.WriteLine($"User : {borrowedUser.name}");
                Console.WriteLine($"Borrowed Date : {borrowedDate}");
                Console.WriteLine($"Return Date : {returnDate}");
            }
            else
            {
                Console.WriteLine("no transaction");
            }

        }public void ReturnBook(int id)
        {
            if (transactionId == id)
            {
                if(borrowedBook != null)
                {
                    borrowedBook.UpdateAvailability(borrowedBook.bookId);
                    Console.WriteLine($"Book '{borrowedBook.title}' returned successfully");
                    
                }
                else
                {
                    Console.WriteLine("No transaction found with the given ID.");
                }
            }
        }
    }
}
